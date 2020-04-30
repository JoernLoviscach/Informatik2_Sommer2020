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

namespace Roboter
{
    public partial class MainWindow : Window
    {
        SuperDuperRoboter robbi = new SuperDuperRoboter(3, 5);
        SuperDuperRoboter robbi2 = new SuperDuperRoboter(4, 2);

        public MainWindow()
        {
            InitializeComponent();
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

    class SuperDuperRoboter // Vorsicht: Klassenname nicht wie Namespace-Name
    {
        // Attribute (Microsoft: "Felder"):
        int x;
        int y; // y-Achse zeigt nach unten!

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
        public SuperDuperRoboter(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        // bewege den Roboter einen Schritt nach rechts
        public void BewegeNachRechts()
        {
            x++;
        }
        // bewege den Roboter einen Schritt nach unten
        public void BewegeNachUnten()
        {
            y++;
        }
    }
}
