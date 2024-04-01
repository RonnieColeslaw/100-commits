using LegoMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace StorageMVC.Controllers
{
    public class DeleteController : Controller
    {
        private readonly string _filePath;

        public DeleteController(IConfiguration configuration)
        {
            _filePath = configuration["FilePath"];
        }

        // GET: LegoController/Delete/5
        public ActionResult Delete(int id)
        {
            ViewBag.SetNumber = id;
            return View();
        }

        // POST: LegoController/Delete/5
        [HttpPost, ActionName("Delete")]
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
