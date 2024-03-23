using Microsoft.AspNetCore.Mvc;

namespace StorageMVC.Controllers
{
    public class PhotoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
