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

/* Vokabeln:
 * [] für Array
 * (int)  (Roboter)  usw.: Casting
 * private, protected, public 
 * static
 * void, int, long, ulong, bool, ..., double, float, string
 * for(;;){}  while(){}  do{}while();  alle mit break und continue
 * if(){} KEINE SCHLEIFE  switch(){case ...: break; default: ...}
 * class (Referenztyp!), struct (Werttyp!)
 * new
 * get, set
 * Doppelpunkt, base (vergleiche: this)
 * abstract, virtual, override
 */

namespace Roboter
{
    public partial class MainWindow : Window
    {
        Standardroboter robbi;
        Standardroboter robbi2;

        public MainWindow() // Konstruktor! Läuft nur einmal kurz am Anfang!
        {
            InitializeComponent();

            robbi = new Standardroboter(zeichenfläche, 3, 5);

            //Polymorphie:
            robbi2 = new Kreisroboter(zeichenfläche, 4, 2);
            // Diese Zuweisung beinhaltet einen Upcast (Kind wird zu Mutter).
            // Upcast ist immer erlaubt.

            //Downcast verlangt ausdrückliche Umwandlung:
            Kreisroboter r = (Kreisroboter)robbi2;
            Kreisroboter t = robbi as Kreisroboter; // unmöglich, liefert deshalb null

            // vergleiche zum Casten:
            double x = (int)0.1234;

            listBoxRoboter.Items.Add(robbi);
            listBoxRoboter.Items.Add(robbi2);
            for (int i = 0; i < 5; i++)
            {
                listBoxRoboter.Items.Add(new Standardroboter(zeichenfläche, i + 2, i + 3));
            }

            ListBoxItem eintrag = new ListBoxItem();
            eintrag.Content = "Hier steht was";
            eintrag.Background = Brushes.Red;
            eintrag.FontFamily = new FontFamily("Times New Roman");
            // Im "Tag" können wir anhängen, was wir wollen!
            eintrag.Tag = listBoxRoboter.Items[3];
            listBoxRoboter.Items.Add(eintrag);
        }

        private void GibKoordinatenAus()
        {
            textBlockAusgabe.Text = robbi.ToString() + "; " + robbi2.ToString();
        }

        private void Button_Click_Runter(object sender, RoutedEventArgs e)
        {
            if (listBoxRoboter.SelectedItem is ListBoxItem)
            {
                ((Standardroboter)((ListBoxItem)listBoxRoboter.SelectedItem).Tag).BewegeNachUnten();
            }
            else
            {
                // Zu den Klammern vergleiche 1 + 2 * 3 * 4 != (1 + 2 * 3) * 4
                ((Standardroboter)listBoxRoboter.SelectedItem).BewegeNachUnten();
            }
            GibKoordinatenAus();
        }

        private void Button_ClickRechts(object sender, RoutedEventArgs e)
        {
            if (listBoxRoboter.SelectedItem is ListBoxItem)
            {
                ((Standardroboter)((ListBoxItem)listBoxRoboter.SelectedItem).Tag).BewegeNachRechts();
            }
            else
            {
                // Zu den Klammern vergleiche 1 + 2 * 3 * 4 != (1 + 2 * 3) * 4
                ((Standardroboter)listBoxRoboter.SelectedItem).BewegeNachRechts();
            }
            GibKoordinatenAus();
        }

        private void Button_ClickNr2Runter(object sender, RoutedEventArgs e)
        {
            robbi2.BewegeNachUnten();
            GibKoordinatenAus();
        }

        private void Button_ClickNr2Rechts(object sender, RoutedEventArgs e)
        {
            robbi2.BewegeNachRechts();
            GibKoordinatenAus();
        }
    }

    class Standardroboter // Vorsicht: Klassenname nicht wie Namespace-Name
    {
        // Attribute (Microsoft: "Felder"):
        int x;
        int y; // y-Achse zeigt nach unten!
        Rectangle quadrat;

        // Properties = Eigenschaften:
        public int X
        {
            get { return x; } // nur get, also nur lesbar
        }
        public int Y
        {
            get { return y; } // nur get, also nur lesbar
        }

        // Methoden:
        // Constructor
        public Standardroboter(Canvas c, int x, int y)
        {
            this.x = x;
            this.y = y;

            quadrat = new Rectangle();
            quadrat.Fill = Brushes.Green;
            quadrat.Width = 10.0;
            quadrat.Height = 10.0;
            c.Children.Add(quadrat);
            Canvas.SetLeft(quadrat, x * 10);
            Canvas.SetTop(quadrat, y * 10); // y-Achse zeigt nach unten!
        }

        // bewege den Roboter einen Schritt nach rechts
        public virtual void BewegeNachRechts()
        {
            x++;
            Canvas.SetLeft(quadrat, x * 10);
        }
        // bewege den Roboter einen Schritt nach unten
        public virtual void BewegeNachUnten()
        {
            y++;
            Canvas.SetTop(quadrat, y * 10);
        }

        public override string ToString()
        {
            return "x = " + X + ", y = " + Y;
        }
    }

    class Kreisroboter : Standardroboter
    {
        Ellipse elli;

        public Kreisroboter(Canvas c, int x, int y)
            : base(c, x, y)
        {
            elli = new Ellipse();
            elli.Fill = Brushes.Orange;
            elli.Width = 10.0;
            elli.Height = 10.0;
            c.Children.Add(elli);
            Canvas.SetLeft(elli, x * 10);
            Canvas.SetTop(elli, y * 10); // y-Achse zeigt nach unten!   
        }

        public override void BewegeNachRechts()
        {
            base.BewegeNachRechts();
            Canvas.SetLeft(elli, X * 10);
        }

        public override void BewegeNachUnten()
        {
            base.BewegeNachUnten();
            Canvas.SetTop(elli, Y * 10);
        }

        public override string ToString()
        {
            return "Hallo!";
        }
    }
}
