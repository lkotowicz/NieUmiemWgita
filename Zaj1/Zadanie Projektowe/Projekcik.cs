using System;

class Program
{
    static void Main()
    {
        ManagerZadan manager = new ManagerZadan();

        while (true)
        {
            Console.WriteLine("\n===== MENU =====");
            Console.WriteLine("1. Dodaj zadanie");
            Console.WriteLine("2. Usuń zadanie");
            Console.WriteLine("3. Wyświetl zadania");
            Console.WriteLine("4. Zapisz listę zadań do pliku");
            Console.WriteLine("5. Wczytaj listę zadań z pliku");
            Console.WriteLine("6. Wyjdź");

            Console.Write("\nWybierz opcję: ");
            string opcja = Console.ReadLine();

            switch (opcja)
            {
                case "1":
                    DodajZadanie(manager);
                    break;
                case "2":
                    UsunZadanie(manager);
                    break;
                case "3":
                    WyswietlZadania(manager);
                    break;
                case "4":
                    ZapiszDoPliku(manager);
                    break;
                case "5":
                    WczytajZPliku(manager);
                    break;
                case "6":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Nieprawidłowa opcja. Wybierz ponownie.");
                    break;
            }
        }
    }

    static void DodajZadanie(ManagerZadan manager)
    {
        Console.WriteLine("\n===== DODAWANIE ZADANIA =====");
        Console.Write("Podaj nazwę zadania: ");
        string nazwa = Console.ReadLine();
        Console.Write("Podaj opis zadania: ");
        string opis = Console.ReadLine();
        Console.Write("Podaj datę zakończenia zadania (RRRR-MM-DD HH:MM:SS): ");
        DateTime dataZakonczenia;
        while (!DateTime.TryParse(Console.ReadLine(), out dataZakonczenia))
        {
            Console.WriteLine("Nieprawidłowy format daty. Podaj ponownie:");
        }

        Zadanie noweZadanie = new Zadanie(manager.PobierzNoweID(), nazwa, opis, dataZakonczenia,false);
        manager.DodajZadanie(noweZadanie);
        Console.WriteLine("Zadanie zostało dodane.");
    }

    static void UsunZadanie(ManagerZadan manager)
    {
        Console.WriteLine("\n===== USUWANIE ZADANIA =====");
        Console.Write("Podaj Id zadania do usunięcia: ");
        int id;
        while (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("Nieprawidłowy format Id. Podaj ponownie:");
        }

        manager.UsunZadanie(id);
    }

    static void WyswietlZadania(ManagerZadan manager)
    {
        Console.WriteLine("\n===== LISTA ZADAŃ =====");
        manager.WyswietlZadania();
    }

    static void ZapiszDoPliku(ManagerZadan manager)
    {
        Console.WriteLine("\n===== ZAPISYWANIE DO PLIKU =====");
        Console.Write("Podaj nazwę pliku: ");
        string nazwaPliku = Console.ReadLine();

        manager.SerializujDoPlikuBinarnego(nazwaPliku);
    }

    static void WczytajZPliku(ManagerZadan manager)
    {
        Console.WriteLine("\n===== WCZYTYWANIE Z PLIKU =====");
        Console.Write("Podaj nazwę pliku: ");
        string nazwaPliku = Console.ReadLine();

        manager.SerializujDoPlikuBinarnego(nazwaPliku);
    }
}
