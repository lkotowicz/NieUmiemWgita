using ProgramowanieDOTNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Garaz
    {
        private string adres;
        private int pojemnosc;
        private int liczbaSamochodow = 0;
        private Samochod[] samochody;

        public string Adres
        {
            get { return adres; }
            set { adres = value; }
        }
        public int Pojemnosc
        {
            get { return pojemnosc; }
            set
            {
                pojemnosc = value;
                samochody = new Samochod[pojemnosc];
            }
        }
        public Garaz()
        
        {
                adres = "nieznany";
                pojemnosc = 0;
                samochody = null;
               
        }
        
        public Garaz(string adres_, int pojemnosc_)
        {
            adres = adres_;
            Pojemnosc = pojemnosc_;
        }
        public void WprowadzSamochod(Samochod samochod)
        {
            if (liczbaSamochodow < pojemnosc)
            {
                samochody[liczbaSamochodow] = samochod;
                liczbaSamochodow++;
                Console.WriteLine("Samochód został wprowadzony do garażu.");
            }
            else
            {
                Console.WriteLine("Garaż jest pełny. Nie można dodać więcej samochodów.");
            }
        }

        public Samochod WyprowadzSamochod()
        {
            if (liczbaSamochodow > 0)
            {
                Samochod ostatniSamochod = samochody[liczbaSamochodow - 1];
                samochody[liczbaSamochodow - 1] = null;
                liczbaSamochodow--;
                Console.WriteLine("Ostatni samochód został wyprowadzony z garażu.");
                return ostatniSamochod;
            }
            else
            {
                Console.WriteLine("Garaż jest pusty. Nie ma samochodów do wyprowadzenia.");
                return null;
            }
        }


        public void WypiszInfo()
        {
            Console.WriteLine($"Adres garażu: {adres}");
            Console.WriteLine($"Pojemność garażu: {pojemnosc}");
            Console.WriteLine($"Liczba samochodów w garażu: {liczbaSamochodow}");

            Console.WriteLine("Informacje o samochodach w garażu:");
            for (int i = 0; i < liczbaSamochodow; i++)
            {
                Console.WriteLine($"Samochód {i + 1}:");
                samochody[i].WypiszInfo();
            }
        }
    }
}

