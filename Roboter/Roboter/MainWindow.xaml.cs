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
        }

        private void GibKoordinatenAus()
        {
            textBlockAusgabe.Text = "x1=" + robbi.X + "; y1=" + robbi.Y + "; x2=" + robbi2.X + "; y2=" + robbi2.Y;
        }

        private void Button_Click_Nr1Runter(object sender, RoutedEventArgs e)
        {
            robbi.BewegeNachUnten();
            GibKoordinatenAus();
        }

        private void Button_ClickNr1Rechts(object sender, RoutedEventArgs e)
        {
            robbi.BewegeNachRechts();
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
    }
}
