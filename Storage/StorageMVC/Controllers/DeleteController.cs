using LegoMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace StorageMVC.Controllers;

public class DeleteController : Controller
{

    private readonly string _filePath;

    public DeleteController(IConfiguration configuration)
    {
        _filePath = configuration["FilePath"];
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
}
