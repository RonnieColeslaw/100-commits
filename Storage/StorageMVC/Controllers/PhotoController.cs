using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StorageMVC.Content.Photos;

namespace StorageMVC.Controllers;

public class PhotoController : Controller
{
    private readonly string _filePath;

    public PhotoController(IConfiguration configuration)
    {
        _filePath = configuration["PhotosFilePath"];
    }
 
}

