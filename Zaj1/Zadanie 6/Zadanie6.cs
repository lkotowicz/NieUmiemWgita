using System;
using System.IO;

class Zadanie6
{
    static void Main()
    {
        Console.WriteLine("Podaj nazwę pliku do skopiowania (zawartość zostanie skopiowana do nowego pliku):");
        string nazwaPlikuWejsciowego = Console.ReadLine();
        using (FileStream plik = new FileStream(nazwaPlikuWejsciowego, FileMode.Create, FileAccess.Write))
        using (BinaryWriter writer = new BinaryWriter(plik))
        {
            // Zapisujemy dane do pliku binarnego
            writer.Write("1111111111111111111111111");
            
        }

        Console.WriteLine("Podaj nazwę nowego pliku (do którego zostanie skopiowana zawartość):");
        string nazwaPlikuWyjsciowego = Console.ReadLine();

        try
        {
            using (FileStream plikWejsciowy = new FileStream(nazwaPlikuWejsciowego, FileMode.Open, FileAccess.Read))
            using (FileStream plikWyjsciowy = new FileStream(nazwaPlikuWyjsciowego, FileMode.Create, FileAccess.Write))
            {
                // Tworzymy bufor do przechowywania danych
                byte[] bufor = new byte[4096];
                int odczytaneBajty;

                // Odczytujemy dane z pliku wejściowego i zapisujemy do pliku wyjściowego
                while ((odczytaneBajty = plikWejsciowy.Read(bufor, 0, bufor.Length)) > 0)
                {
                    plikWyjsciowy.Write(bufor, 0, odczytaneBajty);
                }

                Console.WriteLine("Plik został pomyślnie skopiowany.");
                Console.ReadLine();
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Plik źródłowy nie istnieje."); Console.ReadLine();
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Wystąpił błąd wejścia/wyjścia: {ex.Message}"); Console.ReadLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Wystąpił nieoczekiwany błąd: {ex.Message}"); Console.ReadLine();
        }
    }
}
