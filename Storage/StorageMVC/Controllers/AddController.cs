using LegoMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace StorageMVC.Controllers;

public class AddController : Controller
{
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly SharedServices _sharedService;

    public AddController(SharedServices sharedService, IWebHostEnvironment webHostEnvironment)
    {

        _sharedService = sharedService;
        _webHostEnvironment = webHostEnvironment;
    }

    public ActionResult Create()
    {
        var model = new LegoModel();

        model.SeriesList = new List<SelectListItem>
            {
                new SelectListItem { Value = "Series1", Text = "Series 1" },
             
               
            };

        return View("~/Views/Lego/AddLego.cshtml", model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult CreateSet([FromForm] LegoModel legoModel)
    {
        if (ModelState.IsValid)
        {



            if(legoModel.Photo != null)
            {
                string folder = "photos/lego";
                folder += legoModel.Photo.FileName + Guid.NewGuid().ToString();
                string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);

                legoModel.Photo.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

            }


            var legoSets = _sharedService.GetLegoSets();

            //var decimalPrice = decimal.Parse(legoModel.RetailPrice, CultureInfo.InvariantCulture);

            legoSets.Add(legoModel);
            _sharedService.SaveLegoSets(legoSets);
        }
        else
        {
            return BadRequest(modelState: ModelState);
        }

        return RedirectToAction("StorageAll", "Display");
    }
}
