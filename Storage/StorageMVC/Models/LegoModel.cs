using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LegoMVC.Models
{
    public class LegoModel
    {
        public int Id { get; set; }
        public string SetName { get; set; }

        [Required(ErrorMessage = "The Set Number field is required.")]
        public string SetNumber { get; set; }

        [Required(ErrorMessage = "The Elements Quantity field is required.")]
        public int ElementsQuantity { get; set; }

        public DateTime ReleaseDate { get; set; }
        public decimal RetailPrice { get; set; }
        public decimal ResellPrice { get; set; }
        public string? Warehouse { get; set; }
        public IFormFile Photo { get; set; }

        
        [Required(ErrorMessage = "Please select a series.")]
        public string SelectedSeries { get; set; }

        // Property for holding dropdown list items
        public List<SelectListItem> SeriesList { get; set; }
    }
}
