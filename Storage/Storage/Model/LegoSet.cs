using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Model
{
    public class LegoSet
    {

        public LegoSet(string setName, string setNumber, string series, int elementsQuantity, DateTime releaseDate, decimal retailPrice, decimal resellPrice, string warehouse)
        {
            SetName = setName;
            SetNumber = setNumber;
            Series = series;
            ElementsQuantity = elementsQuantity;
            ReleaseDate = releaseDate;
            RetailPrice = retailPrice;
            Warehouse = warehouse;
        
        }

        public string SetName { get; set; }

        public string SetNumber { get; set; }

        public string Series { get; set; }

        public int ElementsQuantity { get; set; }

        public DateTime ReleaseDate { get; set; }

        public decimal RetailPrice { get; set; }

        public string Warehouse { get; set; }
    }
}
