﻿using LegoMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace StorageMVC.Controllers;

public class AddController : Controller
{
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly SharedServices _sharedService;
    private readonly LegoDbContext _dbContext;

    public AddController(SharedServices sharedService, IWebHostEnvironment webHostEnvironment, LegoDbContext dbContext)
    {
        _sharedService = sharedService;
        _webHostEnvironment = webHostEnvironment;
        _dbContext = dbContext;
    }

    public ActionResult Create()
    {
        var model = new LegoModel();

        model.SeriesList = new List<SelectListItem>
            {   new SelectListItem { Value = "Series3", Text = "LEGO® Architecture" },
                new SelectListItem { Value = "Series1", Text = "LEGO® Art" },
                new SelectListItem { Value = "Series6", Text = "LEGO® BrickHeadz" },
                new SelectListItem { Value = "Series6", Text = "LEGO® City" },
                new SelectListItem { Value = "Series5", Text = "LEGO® Creator" },
                new SelectListItem { Value = "Series6", Text = "LEGO® Duplo" },
                new SelectListItem { Value = "Series4", Text = "LEGO® Ideas" },
                new SelectListItem { Value = "Series6", Text = "LEGO® Minecraft" },
                new SelectListItem { Value = "Series6", Text = "LEGO® Modular Buildings" },
                new SelectListItem { Value = "Series6", Text = "LEGO® Speed Champions" },
                new SelectListItem { Value = "Series2", Text = "LEGO® Star Wars" },
                new SelectListItem { Value = "Series6", Text = "LEGO® Technic" },
                new SelectListItem { Value = "DefSeries", Text = "Other" },


            };

        model.WarehousesList = new List<SelectListItem>
        {
            new SelectListItem {Value = "Warehouse 1", Text = "Warehouse 1"},
            new SelectListItem {Value = "Warehouse 2", Text = "Warehouse 2"}
        };

        return View("~/Views/Lego/AddLego.cshtml", model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> CreateSet([FromForm] LegoModel legoModel)
    {
        if (ModelState.IsValid)
        {
            _dbContext.LegoSets.Add(legoModel);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("StorageAll", "Display");
        }
        else
        {
            return BadRequest(modelState: ModelState);
        }
    }


    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public async ActionResult CreateSet([FromForm] LegoModel legoModel)
    //{
    //    if (ModelState.IsValid)
    //    {
    //        //var legoSets = _sharedService.GetLegoSets();

    //        ////var decimalPrice = decimal.Parse(legoModel.RetailPrice, CultureInfo.InvariantCulture);

    //        //legoSets.Add(legoModel);
    //        //_sharedService.SaveLegoSets(legoSets);

    //        _dbContext.LegoSets.Add(legoModel);
    //        await _dbContext.SaveChangesAsync();

    //        return RedirectToAction("StorageAll", "Display");
    //    }
    //    else
    //    {
    //        return BadRequest(modelState: ModelState);
    //    }

    //}
}
