using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProgramowanieDOTNET
{
    public class Samochod
    {
        private string marka;
        private string model;
        private int iloscDrzwi;
        private int pojemnoscSilnika;
        private double srednieSpalanie;
        private static int liczbaSamochodów = 0;

        // konstruktor domyślny
        public Samochod()
        {
            marka = "Nieznana";
            model = "Nieznany";
            iloscDrzwi = 0;
            pojemnoscSilnika = 0;
            srednieSpalanie = 0;
            liczbaSamochodów++;
        }
        //konstruktor
        public Samochod(string marka_, string model_, int iloscDrzwi_, int pojemnoscSilnika_, double średnieSpalanie_)
        {
            marka=marka_ ;
            model=model_ ;
            iloscDrzwi=iloscDrzwi_;
            pojemnoscSilnika =pojemnoscSilnika_ ;
            srednieSpalanie=średnieSpalanie_ ;
            liczbaSamochodów++;
        }


        // Właściwości
        public string Marka
        {
            get { return marka; }
            set { marka = value; }
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public int IloscDrzwi
        {
            get { return iloscDrzwi; }
            set { iloscDrzwi = value; }
        }

        public int PojemnoscSilnika
        {
            get { return pojemnoscSilnika; }
            set { pojemnoscSilnika = value; }
        }

        public double SrednieSpalanie
        {
            get { return srednieSpalanie; }
            set { srednieSpalanie = value; }
        }

        public static int LiczbaSamochodów
        {
            get { return liczbaSamochodów; }
        }

        // Metody
        private double ObliczSpalanie(double dlugoscTrasy)
        {
            double spalanie = (srednieSpalanie * dlugoscTrasy) / 100.0;

            return spalanie;
        }

        public double ObliczKosztPrzejazdu(double dlugoscTrasy, double cenaPaliwa)
        {
            double spalanie = ObliczSpalanie(dlugoscTrasy); ;
            double kosztPrzejazdu = spalanie * cenaPaliwa;
            return kosztPrzejazdu;



        }
        public void WypiszInfo()
            {
                Console.WriteLine("Marka: " + marka);
                Console.WriteLine("model: " + model);
                Console.WriteLine("iloscDrzwi: " + iloscDrzwi);
                Console.WriteLine("pojemnoscSilnika: " + pojemnoscSilnika);
                Console.WriteLine("srednieSpalanie: " + srednieSpalanie);
                Console.WriteLine("liczbaSamochodów: " + liczbaSamochodów);


            }

            public static void WypiszIloscSamochodow()
            {
                Console.WriteLine("ilosc aut wynosi "+liczbaSamochodów);
            }

            // Destructor
            ~Samochod()
        {
                liczbaSamochodów--;
            }
        }

    }
