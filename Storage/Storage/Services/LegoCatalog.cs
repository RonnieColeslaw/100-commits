using Newtonsoft.Json;
using Storage.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;


namespace Storage.Services
{
    public class LegoCatalog
    {
        private List<LegoSet> LegoSetsList { get; set; } = new List<LegoSet>();

    
        public void AddSet(LegoSet set)
        {
            LegoSetsList.Add(set);
            string serializedSet = JsonConvert.SerializeObject(set);
            SaveToFile(serializedSet);
            Console.WriteLine($"Zestaw {set.SetName} o numerze {set.SetNumber} został dodany do magazynu.");

        }

        public void SaveToFile(string itemToSave)
        {
            string filePath = "C:\\Users\\Dominik Misiak\\Desktop\\LegoSets.txt";
            using StreamWriter sw = new StreamWriter(filePath);
            sw.Write(itemToSave); 
        }

        public void RemoveSet(string input)
        {
            LegoSet setToRemove = LegoSetsList.FirstOrDefault(s => s.SetNumber == input || s.SetName == input);
            if(setToRemove != null )
            {
                LegoSetsList.Remove(setToRemove);
                Console.WriteLine($"Zestaw {setToRemove.SetName} ({setToRemove.SetNumber}) został usunięty.");
            }
            else
            {
                Console.WriteLine("Nie odnaleziono zestawu!");
            }
        }
    }
}
