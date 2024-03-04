using Storage.Model;
using Storage.Services;

namespace LegoStorage;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Witaj w magazynie! Co chcesz zrobić?");
        Console.WriteLine("1.Dodaj zestaw");
        Console.WriteLine("2.Usuń zestaw");
        Console.WriteLine("3.Znajdź zestaw");
        Console.WriteLine("4.Wyświetl wszystkie zestawy");
        Console.WriteLine("X.Zamknij program");

        var userChoice = Console.ReadLine();
        var catalog = new LegoCatalog();
  

        while (true)
        {
            switch (userChoice)
            {
                case "1":
                    Console.WriteLine("Podaj NAZWĘ zestawu:");
                    var input_Name = Console.ReadLine();
                    Console.WriteLine("Podaj SERIĘ zestawu:");
                    var input_Series = Console.ReadLine();
                    Console.WriteLine("Podaj NUMER zestawu:");
                    var input_Number = Console.ReadLine();
                    Console.WriteLine("Podaj ILOŚĆ ELEMENTÓW zestawu:");
                    var input_PartQuantity = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Podaj DATĘ WYDANIA zestawu (yyyy/mm/dd):");
                    var input_ReleaseDate = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Podaj CENĘ SKLEPOWĄ zestawu (PLN):");
                    var input_RetailPrice = decimal.Parse(Console.ReadLine());
                    Console.WriteLine("Podaj CENĘ RYNKOWA zestawu (PLN):");
                    var input_ResellPrice = decimal.Parse(Console.ReadLine());
                    var warehouse = string.Empty;

                    var newSet = new LegoSet(input_Name, input_Number, input_Series, input_PartQuantity, input_ReleaseDate, input_RetailPrice, input_ResellPrice, warehouse);

                    catalog.AddSet(newSet);

                    break;
                case "2":
                    Console.WriteLine("Podaj nazwę lub numer zestawu do usunięcia");
                    var toRemoveSet = Console.ReadLine();

                    catalog.RemoveSet(toRemoveSet);

                    break;
                case "3":
                    Console.WriteLine("Podaj szukany numer zestawu:");
                   

                    break;

                case "4":
                    Console.WriteLine("Wyświetl wszystkie zestawy");
                  
                    break;

                case "x":
                case "X":
                    return;
                default:
                    Console.WriteLine($"Brak opcji: {userChoice}");
                    break;

            }
            Console.WriteLine("Co chcesz zrobić?");
            userChoice = Console.ReadLine();
        }
    }
}