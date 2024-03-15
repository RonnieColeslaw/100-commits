using LegoMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace StorageMVC.Controllers
{
    public class LegoController : Controller
    {

        string filePath = @"C:\Users\Dominik Misiak\Desktop\LegoSets.txt";

        // GET: LegoController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult StorageAll()
        {


            string savedLego = System.IO.File.ReadAllText(filePath);

            var dataList = JsonConvert.DeserializeObject<List<LegoModel>>(savedLego);

            return View("DisplayAll", dataList);

        }


        // GET: LegoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LegoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LegoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LegoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LegoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LegoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LegoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private List<LegoModel> GetLegoSets()
        {
            List<LegoModel> legoSets;
            if (System.IO.File.Exists(filePath))
            {
                string json = System.IO.File.ReadAllText(filePath);
                legoSets = JsonConvert.DeserializeObject<List<LegoModel>>(json);
            }
            else
            {
                legoSets = new List<LegoModel>();
            }
            return legoSets;
        }
        private void SaveLegoSets(List<LegoModel> legoSets)
        {
            string json = JsonConvert.SerializeObject(legoSets, Formatting.Indented);
            System.IO.File.WriteAllText(filePath, json);
        }
    }
}
