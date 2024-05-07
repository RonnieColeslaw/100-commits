using LegoMVC.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StorageMVC.Controllers
{
    public class AddController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly LegoContext _dbContext;

        public AddController(IWebHostEnvironment webHostEnvironment, LegoContext dbContext)
        {
            _webHostEnvironment = webHostEnvironment;
            _dbContext = dbContext;
        }

        public ActionResult Create()
        {
            var model = new LegoModel();

            model.SeriesList = new List<SelectListItem>
            {
                new SelectListItem { Value = "Series1", Text = "LEGO® Architecture" },
                new SelectListItem { Value = "Series2", Text = "LEGO® Art" },
                new SelectListItem { Value = "Series3", Text = "LEGO® BrickHeadz" },
           
                new SelectListItem { Value = "DefSeries", Text = "Other" }
            };

            model.WarehousesList = new List<SelectListItem>
            {
                new SelectListItem { Value = "Warehouse1", Text = "Warehouse 1" },
                new SelectListItem { Value = "Warehouse2", Text = "Warehouse 2" }
            };

            return View("~/Views/Lego/AddLego.cshtml", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateSet(LegoModel legoModel, IFormFile photo)
        {
            if (ModelState.IsValid)
            {
                if(photo != null && photo.Length > 0)
                {
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await photo.CopyToAsync(fileStream);
                    }

                    legoModel.PhotoPath = "/images/" + uniqueFileName; 
                }
                
                _dbContext.LegoModel.Add(legoModel);
                await _dbContext.SaveChangesAsync();

                return RedirectToAction("StorageAll", "Display");
            }
            else
            {
                return View("~/Views/Lego/AddLego.cshtml", legoModel);
            }
        }

    }
}
