using LegoMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace StorageMVC.Controllers;

public class EditController : Controller
{
    private readonly LegoDbContext _context;

    public EditController(LegoDbContext context)
    {
        _context = context;
    }

    public IActionResult Edit(int id)
    {
        LegoModel legoSetToEdit = _context.LegoModel.FirstOrDefault(s => s.SetNumber == id.ToString());

        if (legoSetToEdit == null)
        {
            return NotFound();
        }

        legoSetToEdit.SeriesList = _context.Series
.Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.Name })
.ToList();

        legoSetToEdit.WarehousesList = _context.Warehouses
            .Select(w => new SelectListItem { Value = w.Id.ToString(), Text = w.Name })
            .ToList();

        return View("~/Views/Lego/EditLego.cshtml", legoSetToEdit);
    }
}



//public class EditController : Controller
//{

//    private readonly SharedServices _sharedService;

//    public EditController(SharedServices sharedService)
//    {
//        _sharedService = sharedService;
//    }

//    public ActionResult Edit(int id)
//    {
//        List<LegoModel> legoSets = _sharedService.GetLegoSets();
//        LegoModel legoSetToEdit = legoSets.FirstOrDefault(s => s.SetNumber == id.ToString());


//        legoSetToEdit.SeriesList = new List<SelectListItem>
//    {
//        new SelectListItem { Value = "Series3", Text = "LEGO® Architecture" },
//        new SelectListItem { Value = "Series1", Text = "LEGO® Art" },

//    };


//        legoSetToEdit.WarehousesList = new List<SelectListItem>
//    {
//        new SelectListItem {Value = "Warehouse 1", Text = "Warehouse 1"},
//        new SelectListItem {Value = "Warehouse 2", Text = "Warehouse 2"},

//    };

//        return View("~/Views/Lego/EditLego.cshtml", legoSetToEdit);
//    }


