using Newtonsoft.Json;
using Storage.Model;


namespace Storage.Services
{
    public class LegoCatalog
    {
        private List<LegoSet> LegoSetsList { get; set; } = new List<LegoSet>();
        private List<Warehouse> Warehouses { get; set; } = new List<Warehouse>();

        string filePath = "C:\\Users\\Dominik Misiak\\Desktop\\LegoSets.txt";

        //string filePath = File.ReadAllText(@"./appsettings.json");
        //ConnStrings connStrings = JsonSerializer.Deserialize<ConnStrings>(filePath);



        public void AddSet(LegoSet set)
        {
            LegoSetsList.Add(set);
            string serializedSet = JsonConvert.SerializeObject(set);
            SaveToFile(serializedSet);
            Console.WriteLine($"Zestaw {set.SetName} o numerze {set.SetNumber} został dodany do magazynu.");

        }

        public void SaveToFile(string itemToSave)
        {
            using StreamWriter sw = new StreamWriter(filePath);
            sw.Write(itemToSave);
        }

        public void ReadFromFile()
        {
            try
            {
                using StreamReader sr = new StreamReader(filePath);
                string jsonString = sr.ReadToEnd();
                LegoSetsList = JsonConvert.DeserializeObject<List<LegoSet>>(jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        public void RemoveSet(string input)
        {
            LegoSet setToRemove = LegoSetsList.FirstOrDefault(s => s.SetNumber == input || s.SetName == input);
            if (setToRemove != null)
            {
                LegoSetsList.Remove(setToRemove);
                Console.WriteLine($"Zestaw {setToRemove.SetName} ({setToRemove.SetNumber}) został usunięty.");
            }
            else
            {
                Console.WriteLine("Nie odnaleziono zestawu!");
            }
        }
        private void DisplaySetDetails(List<LegoSet> legoSetsList)
        {

            foreach (var set in LegoSetsList)
            {
                Display(set);
            }
        }
        private void Display(LegoSet set)
        {
            Console.WriteLine($"Zestaw {set.SetNumber} - {set.SetName} z serii {set.Series}, ilość elementów: {set.ElementsQuantity}, data wydania: {set.ReleaseDate}, cena katalogowa: {set.RetailPrice}");
        }
        public void DisplayMatchingSet(string inputPhrase)
        {
            var matchingSets = LegoSetsList.Where(c => c.SetName.Contains(inputPhrase) || c.SetNumber.Contains(inputPhrase)).ToList();
            DisplaySetDetails(matchingSets);

        }
        public void DisplaySetsFromWarehouse(string name)
        {

            var setsFromWarehouse = LegoSetsList.Where(s => s.Warehouse.Contains(name));

            foreach (var warehouse in setsFromWarehouse)
            {
                Console.WriteLine(warehouse.SetName);

            }
        }

        public string SelectRandomWarehouse()
        {

            Warehouses.Add(new Warehouse { Name = "Magazyn 1" });
            Warehouses.Add(new Warehouse { Name = "Magazyn 2" });

            Random r = new Random();
            int index = r.Next(Warehouses.Count);
            string warehouse = Warehouses[index].Name;

            return warehouse;


        }
        public void DisplayAllSets() => DisplaySetDetails(LegoSetsList);


    }
}
