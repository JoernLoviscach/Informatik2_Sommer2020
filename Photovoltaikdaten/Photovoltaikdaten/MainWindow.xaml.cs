using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Photovoltaikdaten
{
    public partial class MainWindow : Window
    {
        double[] erzeugungsdaten = new double[365 * 24 * 4];

        public MainWindow()
        {
            InitializeComponent();

            // Dies wird professionell anders gemacht. Stichwort: Resource-Dateien.
            string[] zeilen = File.ReadAllLines(@"..\..\PV_Sporthalle.csv");
            for (int i = 0; i < 365 * 24 * 4; i++)
            {
                erzeugungsdaten[i] = double.Parse(zeilen[2 + i].Split(';')[2]);
            }

            // Damit schon zu Beginn etwas drin steht.
            zeigeErzeugung();
        }

        private void datePickerAnfangszeitpunkt_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            zeigeErzeugung();
        }

        private void datePickerEndzeitpunkt_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            zeigeErzeugung();
        }

        void zeigeErzeugung()
        {
            // Dieses if erstmal ignorieren!
            if (datePickerAnfangszeitpunkt == null
                || datePickerEndzeitpunkt == null
                || textBlockAusgabe == null)
            {
                return;
            }

            int viertelStundeAnfang = (int)(
                    (datePickerAnfangszeitpunkt.SelectedDate.Value - new DateTime(2017, 1, 1))
                                                                          .TotalMinutes / 15.0
                                           );
            int viertelStundeEnde = (int)(
                    (datePickerEndzeitpunkt.SelectedDate.Value - new DateTime(2017, 1, 1))
                                                                          .TotalMinutes / 15.0
                                         );

            // auf die brutale Art
            double summe = 0.0;
            for (int i = 0; i < 365 * 24 * 4; i++)
            {
                if(viertelStundeAnfang <= i && i < viertelStundeEnde)
                {
                    summe += erzeugungsdaten[i];
                }
            }
            textBlockAusgabe.Text = "In dieser Zeitspanne wurden " + Math.Round(summe, 2) + " kWh eingespeist.";
        }
    }
}
