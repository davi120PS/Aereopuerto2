using Aereopuerto2.Services;
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
using System.Windows.Shapes;

namespace Aereopuerto2.VistaGerenteR
{
    /// <summary>
    /// Lógica de interacción para ReservaGerenteR.xaml
    /// </summary>
    public partial class ReservaGerenteR : Window
    {
        public ReservaGerenteR()
        {
            InitializeComponent();
            GetReservasTable();
        }
        GerenteRServices services = new GerenteRServices();
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            MenuGerenteR vista = new MenuGerenteR();
            vista.Show();
            Close();
        }
        public void SelectItem(object sender, RoutedEventArgs e)
        {
            GestionarReserva vista = new GestionarReserva();
            vista.GetReserva(sender, e);
            vista.Show();
            Close();
        }
        public void GetReservasTable()
        {
            UserTable.ItemsSource = services.GetUsuarios();
        }
    }
}
