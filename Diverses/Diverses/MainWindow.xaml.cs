using System;
using System.Collections.Generic;
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

namespace Diverses
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        class MeineKlasse
        {
            public int x; // Unschön: Felder nicht öffentlich!
        }

        struct MeineStruct
        {
            public int x; // Unschön: Felder nicht öffentlich!
        }

        void Erhöhe(int n)
        {
            n++;
        }

        void Erhöhe(MeineKlasse m)
        {
            m.x++;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            int a = 23;
            int b = a; // int ist Werttyp: Hier wird kopiert!
            b++;
            // a ist immer noch 23.

            Erhöhe(a); // Dies ist sinnlos!

            // Klassen sind Referenztypen
            MeineKlasse c = new MeineKlasse();
            MeineKlasse d = c;
            d.x++;
            // Jetzt ist c.x gleich 1.

            Erhöhe(c); // Das geht, weil c eine Referenz ist!

            // Structs sind Werttypen,
            // in .NET z.B.: DateTime, TimeSpan, Color, Point
            MeineStruct cs = new MeineStruct();
            MeineStruct ds = cs;
            ds.x++;
            // cs.x ist immer noch gleich 0.
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            // Knobelaufgabe mit Referenzen

            List<int> a = new List<int>();
            List<int> b = a;
            a.Add(23);
            a.Add(7);
            a.Add(13);
            a[2] = 4;
            b[1] = 5;
            b.RemoveAt(0);

            List<List<int>> c = new List<List<int>>();
            c.Add(a);
            c.Add(a);
            c.Add(new List<int>());
            c[2].Add(42);
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            // Diese ganze Methode ist nur eine Vorführung davon,
            // dass man eine Zuweisung wie "alt = neu"
            // sinnvoll einsetzen kann.

            // Dies soll iterativ geglättet werden (nur simple Demo):
            List<double> alt = new List<double>() { 7.0, 13.0, 23.0 };

            for (int i = 0; i < 4; i++) // Glättungsdurchgänge durch komplette Punktfolge
            {
                List<double> neu = new List<double>();
                for (int j = 0; j < alt.Count; j++)
                {
                    neu.Add(alt[j]);
                    if (j < alt.Count - 1)
                    {
                        // Man müsste für eine weiche Glättung
                        // etwas Klügeres nehmen als den Mittelwert hier:
                        double mittelwert = 0.5 * (alt[j] + alt[j + 1]);
                        neu.Add(mittelwert);
                    }
                }
                alt = neu;
            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            label.Content = "";

            int a = -999; // besser: Typ "int?"
            try
            {
                a = int.Parse(textBox.Text);
                if(a > 1000)
                {
                    throw new ApplicationException("Wert war über 1000!");
                }
                int b = 42 / a;
                int[] c = new int[23];
                int d = c[a];
            }
            catch (DivideByZeroException ex)
            {
                MessageBox.Show("Es wurde durch 0 geteilt!\n" + ex.Source);
            }
            catch (Exception ex)
            {
                label.Content = ex.Message;
            }
            finally
            {
                // Wird immer ausgeführt, ob mit oder ohne Exception,
                // zum Beispiel, um eine Datei zu schließen, 
                // die im try geöffnet worden ist.
                // Achtung: War die Exception schon vor dem Öffnen der Datei?
            }

            int f = a * a;
        }
    }
}
