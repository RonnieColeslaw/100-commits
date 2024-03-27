using LegoMVC.Models;
using Newtonsoft.Json;

namespace StorageMVC.Controllers;

public class SharedServices
{
    private readonly string _filePath;

    public SharedServices(IConfiguration configuration)
    {
        _filePath = configuration["FilePath"];
    }
    public List<LegoModel> GetLegoSets()
    {
        List<LegoModel> legoSets;

       if (System.IO.File.Exists(_filePath))
        {
            string json = System.IO.File.ReadAllText(_filePath);
            legoSets = JsonConvert.DeserializeObject<List<LegoModel>>(json);
           
            if (legoSets == null)
            {
                legoSets = new List<LegoModel>();
            }
        }
        else
        {
            legoSets = new List<LegoModel>();
        }
        return legoSets;
    }
    public void SaveLegoSets(List<LegoModel> legoSets)
    {
        string json = JsonConvert.SerializeObject(legoSets, Formatting.Indented);
        System.IO.File.WriteAllText(_filePath, json);
    }
}
