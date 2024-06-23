using System;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.WindowsForms;


namespace CosinePlotApp
{
    public class MainForm : Form
    {
        private PlotView plotView;

        public MainForm()
        {
            // Ustawienia okna głównego
            this.Text = "Wykres sinusa";
            this.Width = 800;
            this.Height = 600;

            // Inicjalizacja PlotView
            plotView = new PlotView
            {
                Dock = DockStyle.Fill
            };
            this.Controls.Add(plotView);

            // Rysowanie wykresu cosinusa
            PlotCosine();
        }

        private void PlotCosine()
        {
            // Utworzenie modelu wykresu
            var plotModel = new PlotModel { Title = "Wykres funkcji sin(x)" };

            // Utworzenie serii danych
            var series = new LineSeries { Title = "sin(x)" };

            // Dodanie punktów do serii
            for (double x = 0; x <= 2 * Math.PI; x += 0.01)
            {
                series.Points.Add(new DataPoint(x, Math.Sin(x)));
            }

            // Dodanie serii do modelu wykresu
            plotModel.Series.Add(series);

            // Ustawienie modelu wykresu w PlotView
            plotView.Model = plotModel;
        }

        [STAThread]
        public static void Main()
        {
            // Uruchomienie aplikacji
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
