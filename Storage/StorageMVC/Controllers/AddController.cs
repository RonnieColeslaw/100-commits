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

    public ActionResult Create()
    {
        return View("~/Views/Lego/AddLego.cshtml");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult CreateSet([FromBody] LegoModel legoModel)
    {
        if (ModelState.IsValid)
        {
            var legoSets = _sharedService.GetLegoSets();

            //var decimalPrice = decimal.Parse(legoModel.RetailPrice, CultureInfo.InvariantCulture);

            legoSets.Add(legoModel);
            _sharedService.SaveLegoSets(legoSets);
        }
        else
        {
            return BadRequest(modelState: ModelState);
        }
       
    return RedirectToAction("StorageAll");
    }
}
