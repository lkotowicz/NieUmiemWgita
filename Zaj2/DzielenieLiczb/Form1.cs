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
                // Pobranie warto�ci z p�l tekstowych
                double dzielna = Convert.ToDouble(TextBox1.Text);
                double dzielnik = Convert.ToDouble(TextBox2.Text);

                // Sprawdzenie, czy dzielnik nie jest zerem
                if (dzielnik == 0)
                {
                    string errorMessage = "Dzielnik nie mo�e by� zerem.";
                    MessageBox.Show(errorMessage, "B��d", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogErrorToEventViewer(errorMessage);
                    return;
                }

                // Obliczenie wyniku
                double wynik = dzielna / dzielnik;

                // Wy�wietlenie wyniku w polu tekstowym
                TextBox3.Text = wynik.ToString();
            }
            catch (FormatException ex)
            {
                string errorMessage = "Prosz� wprowadzi� prawid�owe liczby.";
                MessageBox.Show(errorMessage, "B��d", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogErrorToEventViewer(ex.ToString());
            }
            catch (OverflowException ex)
            {
                string errorMessage = "Wprowadzona liczba jest za du�a lub za ma�a.";
                MessageBox.Show(errorMessage, "B��d", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogErrorToEventViewer(ex.ToString());
            }
            catch (Exception ex)
            {
                string errorMessage = "Wyst�pi� nieoczekiwany b��d: " + ex.Message;
                MessageBox.Show(errorMessage, "B��d", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogErrorToEventViewer(ex.ToString());
            }
        }

        private void LogErrorToEventViewer(string errorMessage)
        {
            // Nazwa �r�d�a zdarze�
            string source = "DzielenieLiczb";
            // Nazwa logu
            string log = "Application";

            // Sprawdzenie, czy �r�d�o zdarze� istnieje
            if (!EventLog.SourceExists(source))
            {
                EventLog.CreateEventSource(source, log);
            }

            // Zapisanie zdarzenia do dziennika zdarze�
            EventLog.WriteEntry(source, errorMessage, EventLogEntryType.Error);
        }
    }
}
