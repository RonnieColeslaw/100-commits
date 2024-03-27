using System.Diagnostics.CodeAnalysis;
using System.Web.Mvc;

namespace LegoMVC.Models;

public class LegoModel
{
    public int Id { get; set; }
    public string SetName { get; set; }

    public string SetNumber { get; set; }

    public string Series { get; set; }

    public int ElementsQuantity { get; set; }

    public DateTime ReleaseDate { get; set; }

    public decimal RetailPrice { get; set; }
    public decimal ResellPrice { get; set; }
    
    public string? Warehouse { get; set; }

    //[AllowHtml]
    //public byte[] Image { get; set; }


}
