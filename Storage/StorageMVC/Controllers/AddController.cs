using LegoMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace StorageMVC.Controllers;

public class AddController : Controller
{

    private readonly SharedServices _sharedService;

    public AddController(SharedServices sharedService)
    {
        _sharedService = sharedService;
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult CreateSet(LegoModel legoModel)
    {
        var legoSets = _sharedService.GetLegoSets();

        //var decimalPrice = decimal.Parse(legoModel.RetailPrice, CultureInfo.InvariantCulture);

        legoSets.Add(legoModel);
        _sharedService.SaveLegoSets(legoSets);
       
    return RedirectToAction("StorageAll");
    }
}
