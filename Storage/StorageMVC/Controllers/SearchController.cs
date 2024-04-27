using LegoMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace StorageMVC.Controllers;

public class SearchController : Controller
{
    private readonly LegoDbContext _context;

    public SearchController(LegoDbContext context)
    {
        _context = context;
    }

    public IActionResult Search(string input)
    {
        var legoSetToFind = _context.LegoModels.FirstOrDefault(s => s.SetName.ToLower().Contains(input.ToLower()));

        return View("~/Views/Lego/SearchResults.cshtml", legoSetToFind);
    }
}

//public class SearchController : Controller
//{
//    private readonly SharedServices _sharedService;

//    public SearchController(SharedServices sharedService)
//    {
//        _sharedService = sharedService;
//    }

//    public ActionResult Search(string input)
//    {
//        List<LegoModel> legoSets = _sharedService.GetLegoSets();
//        LegoModel legoSetToFind = legoSets.FirstOrDefault(s => s.SetName.ToLower().Contains(input.ToLower()));

//        return View("~/Views/Lego/SearchResults.cshtml", legoSetToFind);
//    }
//}

