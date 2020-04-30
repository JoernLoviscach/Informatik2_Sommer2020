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

namespace Roboter2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Baue einen Roboter
            //Roboter 机械人 = new Roboter();

            ////und bewege ihn nach rechts und nach unten
            //机械人.BewegeNachRechts();
            //机械人.BewegeNachUnten();

        }
    }

    class Roboter
    {
        // Attribute (Microsoft: "Felder"):
        int x;
        int y; // y-Achse zeigt nach unten!

        // Methoden:
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
