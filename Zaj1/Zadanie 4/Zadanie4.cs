using System;
using System.IO;

class Zadanie4
{
    static void Main()
    {
        string nazwaPliku = "F:\\studia\\Sem IV\\dotnet\\Zadanie4\\tekstowy_plik.txt"; // Ścieżka do pliku tekstowego

        try
        {
            // Otwieramy plik tekstowy do odczytu
            using (StreamReader sr = new StreamReader(nazwaPliku))
            {
                string linia;

                // Czytamy linia po linii
                while ((linia = sr.ReadLine()) != null)
                {
                    // Odwracamy kolejność znaków w linii
                    char[] odwroconaLinia = new char[linia.Length];
                    for (int i = 0; i < linia.Length; i++)
                    {
                        odwroconaLinia[i] = linia[linia.Length - 1 - i];
                    }

                    // Wyświetlamy odwróconą linię na konsoli
                    Console.WriteLine(odwroconaLinia);
                }
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
