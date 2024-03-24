using LegoMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace StorageMVC.Controllers;

public class DisplayController : Controller
{

    private readonly string _filePath;

    public DisplayController(IConfiguration configuration)
    {
        _filePath = configuration["FilePath"];
    }
    public ActionResult StorageAll()
    {

        //string filePath = _configuration["FilePath"];
        string savedLego = System.IO.File.ReadAllText(_filePath);

        var dataList = JsonConvert.DeserializeObject<List<LegoModel>>(savedLego);

        return View("~/Views/Lego/DisplayAll.cshtml", dataList);
    }
}
