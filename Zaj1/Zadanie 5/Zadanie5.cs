using System;
using System.IO;

class Zadanie5
{
   
    static void Main()
    {
        Console.WriteLine("Wybierz operację:");
        Console.WriteLine("1. Zapisz dane do pliku binarnego");
        Console.WriteLine("2. Odczytaj dane z pliku binarnego");

        string wybor = Console.ReadLine();

        switch (wybor)
        {
            case "1":
                ZapiszDoPliku();
                break;
            case "2":
                OdczytajZPliku();
                break;
            default:
                Console.WriteLine("Nieprawidłowy wybór.");
                break;
        }
    }

    static void ZapiszDoPliku()
    {
        Console.WriteLine("Podaj imię:");
        string imie = Console.ReadLine();

        Console.WriteLine("Podaj wiek:");
        int wiek = int.Parse(Console.ReadLine());

        Console.WriteLine("Podaj adres:");
        string adres = Console.ReadLine();

        try
        {
            using (FileStream plik = new FileStream("dane.bin", FileMode.Create, FileAccess.Write))
            using (BinaryWriter writer = new BinaryWriter(plik))
            {
                // Zapisujemy dane do pliku binarnego
                writer.Write(imie);
                writer.Write(wiek);
                writer.Write(adres);
            }

            Console.WriteLine("Dane zostały zapisane do pliku.");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Wystąpił błąd wejścia/wyjścia: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Wystąpił nieoczekiwany błąd: {ex.Message}");
        }
        Console.ReadKey();
    }

    static void OdczytajZPliku()
    {
        try
        {
            using (FileStream plik = new FileStream("dane.bin", FileMode.Open, FileAccess.Read))
            using (BinaryReader reader = new BinaryReader(plik))
            {
                // Odczytujemy dane z pliku binarnego
                string imie = reader.ReadString();
                int wiek = reader.ReadInt32();
                string adres = reader.ReadString();

                // Wyświetlamy odczytane dane na ekranie
                Console.WriteLine("Odczytane dane:");
                Console.WriteLine($"Imię: {imie}");
                Console.WriteLine($"Wiek: {wiek}");
                Console.WriteLine($"Adres: {adres}");
                Console.ReadKey();
            }
            
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Plik 'dane.bin' nie istnieje.");
            Console.ReadKey();
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Wystąpił błąd wejścia/wyjścia: {ex.Message}");
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Wystąpił nieoczekiwany błąd: {ex.Message}");
            Console.ReadKey();
        }
    }
}
