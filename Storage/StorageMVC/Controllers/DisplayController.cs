using LegoMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace StorageMVC.Controllers;

   public class DisplayController : Controller
    {
        private readonly LegoDbContext _context; 

        public DisplayController(LegoDbContext context) 
        {
            _context = context;
        }

        public async Task<ActionResult> StorageAll() 
        {
            
            var dataList = await _context.LegoModel.ToListAsync(); 

            return View("~/Views/Lego/DisplayAll.cshtml", dataList);
        }
    }




//public class DisplayController : Controller
//{

//    private readonly string _filePath;

//    public DisplayController(IConfiguration configuration)
//    {
//        _filePath = configuration["FilePath"];
//    }
//    public ActionResult StorageAll()
//    {

//        //string filePath = _configuration["FilePath"];
//        string savedLego = System.IO.File.ReadAllText(_filePath);

//        var dataList = JsonConvert.DeserializeObject<List<LegoModel>>(savedLego);

//        return View("~/Views/Lego/DisplayAll.cshtml", dataList);
//    }
//}
