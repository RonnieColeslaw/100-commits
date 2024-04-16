using LegoMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace StorageMVC.Controllers
{
    public class SearchController : Controller
    {
        private readonly SharedServices _sharedService;

        public SearchController(SharedServices sharedService)
        {
            _sharedService = sharedService;
        }

        public ActionResult Search(string input)
        {
            List<LegoModel> legoSets = _sharedService.GetLegoSets();
            LegoModel legoSetToFind = legoSets.FirstOrDefault(s => s.SetName.ToLower().Contains(input.ToLower()));

            return View("~/Views/Lego/SearchResults.cshtml", legoSetToFind);
        }
    }
}
