using LegoMVC.Models;
using Microsoft.AspNetCore.Mvc;
using StorageMVC.Controllers;



namespace StorageMVC.Controllers;

public class EditController : Controller
{

    private readonly SharedServices _sharedService;

    public EditController(SharedServices sharedService)
    {
        _sharedService = sharedService;
    }

    public ActionResult Edit(int id)
    {
        List<LegoModel> legoSets = _sharedService.GetLegoSets();
        LegoModel legoSetToEdit = legoSets.FirstOrDefault(s => s.SetNumber == id.ToString());

        return View("~/Views/Lego/EditLego.cshtml", legoSetToEdit);
    }
}
