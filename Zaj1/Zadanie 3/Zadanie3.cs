using System;
using System.IO;
using System.Text;

class Zadanie3
{
    static void Main()
    {
        string nazwaPliku = "F:\\studia\\Sem IV\\dotnet\\ConsoleApp2\\tekstowy_plik.txt"; // // Ścieżka do pliku tekstowego

        try
        {
            // Otwieramy plik tekstowy w trybie do odczytu za pomocą FileStream
            using (FileStream plik = new FileStream(nazwaPliku, FileMode.Open, FileAccess.Read))
            {
                // Tworzymy bufor do przechowywania odczytanych danych
                byte[] bufor = new byte[plik.Length];

                // Odczytujemy dane z pliku
                plik.Read(bufor, 0, bufor.Length);

                // Konwertujemy odczytane dane na tekst za pomocą kodowania UTF-8
                string tekst = Encoding.UTF8.GetString(bufor);

                // Wyświetlamy odczytany tekst na konsoli
                Console.WriteLine("Zawartość pliku:");
                Console.WriteLine(tekst);
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Plik '{nazwaPliku}' nie istnieje.");
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
}
