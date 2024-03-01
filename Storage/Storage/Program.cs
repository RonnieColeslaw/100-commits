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
    }
}