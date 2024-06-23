using System;
using System.Diagnostics;
using System.IO;

class Zadanie7
{
    static void Main()
    {
        string nazwaPliku = "testowy_plik.bin";
        long wielkoscPlikuMB = 300;
        int rozmiarBufora = 8192; // Rozmiar bufora dla BufferedStream

        // Generowanie pliku o określonej wielkości
        Console.WriteLine($"Generowanie pliku o wielkości {wielkoscPlikuMB} MB...");
        GenerujPlik(nazwaPliku, wielkoscPlikuMB);

        // Testowanie wydajności kopiowania pliku za pomocą różnych metod
        Console.WriteLine("Testowanie wydajności kopiowania pliku...");

        // Pomiar czasu kopiowania za pomocą File.Copy
        Stopwatch stoperFileCopy = new Stopwatch();
        stoperFileCopy.Start();
        File.Copy(nazwaPliku, "file_copy.bin");
        stoperFileCopy.Stop();
        Console.WriteLine($"Czas kopiowania za pomocą File.Copy: {stoperFileCopy.ElapsedMilliseconds} ms");

        // Pomiar czasu kopiowania za pomocą FileStream
        Stopwatch stoperFileStream = new Stopwatch();
        stoperFileStream.Start();
        using (FileStream plikWejsciowy = new FileStream(nazwaPliku, FileMode.Open, FileAccess.Read))
        using (FileStream plikWyjsciowy = new FileStream("file_stream.bin", FileMode.Create, FileAccess.Write))
        {
            byte[] bufor = new byte[rozmiarBufora];
            int odczytaneBajty;
            while ((odczytaneBajty = plikWejsciowy.Read(bufor, 0, bufor.Length)) > 0)
            {
                plikWyjsciowy.Write(bufor, 0, odczytaneBajty);
            }
        }
        stoperFileStream.Stop();
        Console.WriteLine($"Czas kopiowania za pomocą FileStream: {stoperFileStream.ElapsedMilliseconds} ms");

        // Pomiar czasu kopiowania za pomocą BufferedStream
        Stopwatch stoperBufferedStream = new Stopwatch();
        stoperBufferedStream.Start();
        using (FileStream plikWejsciowy = new FileStream(nazwaPliku, FileMode.Open, FileAccess.Read))
        using (FileStream plikWyjsciowy = new FileStream("buffered_stream.bin", FileMode.Create, FileAccess.Write))
        using (BufferedStream bufferedStream = new BufferedStream(plikWyjsciowy, rozmiarBufora))
        {
            byte[] bufor = new byte[rozmiarBufora];
            int odczytaneBajty;
            while ((odczytaneBajty = plikWejsciowy.Read(bufor, 0, bufor.Length)) > 0)
            {
                bufferedStream.Write(bufor, 0, odczytaneBajty);
            }
        }
        stoperBufferedStream.Stop();
        Console.WriteLine($"Czas kopiowania za pomocą BufferedStream: {stoperBufferedStream.ElapsedMilliseconds} ms");

        // Usuń wygenerowane pliki
        File.Delete("file_copy.bin");
        File.Delete("file_stream.bin");
        File.Delete("buffered_stream.bin");

        Console.WriteLine("Test zakończony.");
        Console.ReadKey();
    }

    static void GenerujPlik(string nazwaPliku, long wielkoscPlikuMB)
    {
        byte[] dane = new byte[1024 * 1024]; // 1 MB
        using (FileStream plik = new FileStream(nazwaPliku, FileMode.Create, FileAccess.Write))
        {
            for (long i = 0; i < wielkoscPlikuMB; i++)
            {
                plik.Write(dane, 0, dane.Length);
            }
        }
    }
    
}
