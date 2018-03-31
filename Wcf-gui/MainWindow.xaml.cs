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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wcf_gui.ServiceReference1;

namespace Wcf_gui
{
    public partial class MainWindow : Window
    {
        private ServiceReference1.Service1Client client;
        public string Ville { get; set; }
        public string Station { get; set; }
        public ListView list;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            list = this.FindName("listView") as ListView;
            this.client = new ServiceReference1.Service1Client();
        }

        /// <summary>
        /// Affiche le nombre de vélo disponible pour une station
        /// </summary>
        private void NbVelo_click(object sender, RoutedEventArgs e)
        {
            this.list.Items.Clear();
            Station tmp = new Station()
            {
                available_bikes = this.client.GetNumberAvailableBike(Ville.ToString().ToUpper(),
                                    Station.ToString().ToUpper()),
                name = Ville.ToString().ToUpper(),
                address = "?"
            };
            this.list.Items.Add(tmp);
        }

        /// <summary>
        /// Affiche les stations d'une ville
        /// </summary>
        private void StationDisponible_click(object sender, RoutedEventArgs e)
        {
            this.list.Items.Clear();
            foreach (Station station in this.client.GetStations(Ville.ToString().ToUpper()))
            {
                this.list.Items.Add(station);
            }
        }

    }
}
