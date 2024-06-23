using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Kalkulator
{
    public partial class Form1 : Form
    {
        private double result = 0;
        private string operation = "";
        private bool isOperationPerformed = false;
        private const int InitializationThresholdMilliseconds = 10; // Próg czasowy w milisekundach, 10ms aby coœ siê nam zalogowa³o

        public Form1()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            InitializeComponent();

            stopwatch.Stop();
            long initializationTime = stopwatch.ElapsedMilliseconds;

            if (initializationTime > InitializationThresholdMilliseconds)
            {
                string message = $"Initialization time exceeded threshold: {initializationTime} ms";
                LogErrorToEventViewer(message);
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            if ((resultTextBox.Text == "0") || (isOperationPerformed))
                resultTextBox.Clear();

            isOperationPerformed = false;
            Button button = (Button)sender;
            resultTextBox.Text = resultTextBox.Text + button.Text;
        }

        private void operator_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            operation = button.Text;
            result = Double.Parse(resultTextBox.Text);
            isOperationPerformed = true;
        }

        private void buttonEquals_Click(object sender, EventArgs e)
        {
            switch (operation)
            {
                case "+":
                    resultTextBox.Text = (result + Double.Parse(resultTextBox.Text)).ToString();
                    break;
                case "-":
                    resultTextBox.Text = (result - Double.Parse(resultTextBox.Text)).ToString();
                    break;
                case "*":
                    resultTextBox.Text = (result * Double.Parse(resultTextBox.Text)).ToString();
                    break;
                case "/":
                    resultTextBox.Text = (result / Double.Parse(resultTextBox.Text)).ToString();
                    break;
                default:
                    break;
            }
            result = Double.Parse(resultTextBox.Text);
            operation = "";
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            resultTextBox.Text = "0";
            result = 0;
        }
        private void LogErrorToEventViewer(string errorMessage)
        {
            // Nazwa Ÿród³a zdarzeñ
            string source = "Kalkulator";
            // Nazwa logu
            string log = "Application";

            try
            {
                // Sprawdzenie, czy Ÿród³o zdarzeñ istnieje
                if (!EventLog.SourceExists(source))
                {
                    EventLog.CreateEventSource(source, log);
                }

                // Zapisanie zdarzenia do dziennika zdarzeñ
                EventLog.WriteEntry(source, errorMessage, EventLogEntryType.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nie uda³o siê zapisaæ zdarzenia do dziennika zdarzeñ: " + ex.Message, "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

