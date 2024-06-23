using System;
using System.Windows.Forms;
using System.Diagnostics;

namespace DzielenieLiczb
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Pobranie wartoœci z pól tekstowych
                double dzielna = Convert.ToDouble(TextBox1.Text);
                double dzielnik = Convert.ToDouble(TextBox2.Text);

                // Sprawdzenie, czy dzielnik nie jest zerem
                if (dzielnik == 0)
                {
                    string errorMessage = "Dzielnik nie mo¿e byæ zerem.";
                    MessageBox.Show(errorMessage, "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogErrorToEventViewer(errorMessage);
                    return;
                }

                // Obliczenie wyniku
                double wynik = dzielna / dzielnik;

                // Wyœwietlenie wyniku w polu tekstowym
                TextBox3.Text = wynik.ToString();
            }
            catch (FormatException ex)
            {
                string errorMessage = "Proszê wprowadziæ prawid³owe liczby.";
                MessageBox.Show(errorMessage, "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogErrorToEventViewer(ex.ToString());
            }
            catch (OverflowException ex)
            {
                string errorMessage = "Wprowadzona liczba jest za du¿a lub za ma³a.";
                MessageBox.Show(errorMessage, "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogErrorToEventViewer(ex.ToString());
            }
            catch (Exception ex)
            {
                string errorMessage = "Wyst¹pi³ nieoczekiwany b³¹d: " + ex.Message;
                MessageBox.Show(errorMessage, "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogErrorToEventViewer(ex.ToString());
            }
        }

        private void LogErrorToEventViewer(string errorMessage)
        {
            // Nazwa Ÿród³a zdarzeñ
            string source = "DzielenieLiczb";
            // Nazwa logu
            string log = "Application";

            // Sprawdzenie, czy Ÿród³o zdarzeñ istnieje
            if (!EventLog.SourceExists(source))
            {
                EventLog.CreateEventSource(source, log);
            }

            // Zapisanie zdarzenia do dziennika zdarzeñ
            EventLog.WriteEntry(source, errorMessage, EventLogEntryType.Error);
        }
    }
}
