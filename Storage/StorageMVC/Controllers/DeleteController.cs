using LegoMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace StorageMVC.Controllers
{
    public class DeleteController : Controller
    {
        private readonly string _filePath;

        public DeleteController(IConfiguration configuration)
        {
            _filePath = configuration["FilePath"];
        }

        // GET: Delete/Delete/5
        public ActionResult Delete(int id)
        {
            ViewBag.SetNumber = id;
            return View("~/Views/Lego/DeleteConfirmation.cshtml");
        }

        // POST: Delete/DeleteConfirmed/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            string savedLego = System.IO.File.ReadAllText(_filePath);

            List<LegoModel> dataList = JsonConvert.DeserializeObject<List<LegoModel>>(savedLego);

            LegoModel legoToRemove = dataList.FirstOrDefault(l => l.SetNumber == id.ToString());

            if (legoToRemove != null)
            {
                dataList.Remove(legoToRemove);

                string updatedLegoSet = JsonConvert.SerializeObject(dataList, Formatting.Indented);

                System.IO.File.WriteAllText(_filePath, updatedLegoSet);
            }
            return RedirectToAction("StorageAll", "Display");
        }
    }
}
