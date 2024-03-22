using LegoMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace StorageMVC.Controllers;

public class LegoController : Controller
{
    //private readonly IConfiguration _configuration;
    private readonly string _filePath;

    public LegoController(IConfiguration configuration)
    {
        _filePath = configuration["FilePath"];
    }
    public ActionResult Index()
    {
        return View();
    }

    public ActionResult StorageAll()
    {

        //string filePath = _configuration["FilePath"];
        string savedLego = System.IO.File.ReadAllText(_filePath);

        var dataList = JsonConvert.DeserializeObject<List<LegoModel>>(savedLego);

        return View("DisplayAll", dataList);
    }

    // GET: LegoController/Details/5
    public ActionResult Details(int id)
    {
        return View();
    }

    // GET: LegoController/Edit/5
    public ActionResult Edit(int id)
    {
        List<LegoModel> legoSets = GetLegoSets();
        LegoModel legoSetToEdit = legoSets.FirstOrDefault(s => s.SetNumber == id.ToString());

        return View("EditLego", legoSetToEdit);
    }

    // POST: LegoController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id)
    {
        string savedLego = System.IO.File.ReadAllText(_filePath);

        List<LegoModel> dataList = JsonConvert.DeserializeObject<List<LegoModel>>(savedLego);

        LegoModel legoToRemove = dataList.FirstOrDefault(l => l.SetNumber == id.ToString());

        if (legoToRemove != null)
        {
            dataList.Remove(legoToRemove);

            string updatedLegoSet = JsonConvert.SerializeObject(dataList, Formatting.Indented);

            System.IO.File.WriteAllText(_filePath, updatedLegoSet);
        }
        return RedirectToAction("StorageAll");
    }

    private List<LegoModel> GetLegoSets()
    {
        List<LegoModel> legoSets;
        if (System.IO.File.Exists(_filePath))
        {
            string json = System.IO.File.ReadAllText(_filePath);
            legoSets = JsonConvert.DeserializeObject<List<LegoModel>>(json);
        }
        else
        {
            legoSets = new List<LegoModel>();
        }
        return legoSets;
    }
    private void SaveLegoSets(List<LegoModel> legoSets)
    {
        string json = JsonConvert.SerializeObject(legoSets, Formatting.Indented);
        System.IO.File.WriteAllText(_filePath, json);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult CreateSet(LegoModel legoModel)
    {
        var legoSets = GetLegoSets();

        //var decimalPrice = decimal.Parse(legoModel.RetailPrice, CultureInfo.InvariantCulture);

        legoSets.Add(legoModel);
        SaveLegoSets(legoSets);

        return RedirectToAction("StorageAll");
    }
}

