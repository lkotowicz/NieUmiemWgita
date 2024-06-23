using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;



public class ManagerZadan
{
    private List<Zadanie> listaZadan;

    public ManagerZadan()
    {
        listaZadan = new List<Zadanie>();
    }

    public void DodajZadanie(Zadanie zadanie)
    {
        zadanie.Id = PobierzNoweID();
        listaZadan.Add(zadanie);
    }

    public void UsunZadanie(int id)
    {
        Zadanie zadanie = listaZadan.FirstOrDefault(z => z.Id == id);
        if (zadanie != null)
        {
            listaZadan.Remove(zadanie);
            Console.WriteLine($"Usunięto zadanie o ID {id}.");
        }
        else
        {
            Console.WriteLine($"Nie znaleziono zadania o ID {id}.");
        }
    }

    public void WyswietlZadania()
    {
        if (listaZadan.Count > 0)
        {
            Console.WriteLine("Lista zadań:");
            foreach (var zadanie in listaZadan)
            {
                Console.WriteLine(zadanie);
            }
        }
        else
        {
            Console.WriteLine("Lista zadań jest pusta.");
        }
    }

    public int PobierzNoweID()
    {
        if (listaZadan.Count == 0)
        {
            return 1;
        }

        var existingIds = listaZadan.Select(z => z.Id).OrderBy(id => id).ToList();
        int newId = 1;

        foreach (int id in existingIds)
        {
            if (id == newId)
            {
                newId++;
            }
            else
            {
                break;
            }
        }

        return newId;
    }

    // Inne metody...

    public void SerializujDoPlikuBinarnego(string nazwaPliku)
    {
        try
        {
            using (FileStream plik = new FileStream(nazwaPliku, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(plik, listaZadan);
            }
            Console.WriteLine("Serializacja do pliku binarnego zakończona pomyślnie.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Wystąpił błąd podczas serializacji do pliku binarnego: {ex.Message}");
        }
    }

    public void DeserializujZPlikuBinarnego(string nazwaPliku)
    {
        try
        {
            using (FileStream plik = new FileStream(nazwaPliku, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                listaZadan = (List<Zadanie>)formatter.Deserialize(plik);
            }
            Console.WriteLine("Deserializacja z pliku binarnego zakończona pomyślnie.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Wystąpił błąd podczas deserializacji z pliku binarnego: {ex.Message}");
        }
    }

    public void SerializujDoPlikuJson(string nazwaPliku)
    {
        try
        {
            string json = JsonConvert.SerializeObject(listaZadan);
            File.WriteAllText(nazwaPliku, json);
            Console.WriteLine("Serializacja do pliku JSON zakończona pomyślnie.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Wystąpił błąd podczas serializacji do pliku JSON: {ex.Message}");
        }
    }

    public void DeserializujZPlikuJson(string nazwaPliku)
    {
        try
        {
            string json = File.ReadAllText(nazwaPliku);
            listaZadan = JsonConvert.DeserializeObject<List<Zadanie>>(json);
            Console.WriteLine("Deserializacja z pliku JSON zakończona pomyślnie.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Wystąpił błąd podczas deserializacji z pliku JSON: {ex.Message}");
        }
    }
}
