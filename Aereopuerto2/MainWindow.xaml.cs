using Aereopuerto2.VistaCliente;
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

namespace Aereopuerto2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            Login Login = new Login();
            Login.Show();
            Close();
        }
        private void BtnGenR_Click(object sender, RoutedEventArgs e)
        {
            ReservaCliente vista = new ReservaCliente();
            vista.Show();
            Close();
        }
        private void BtnConR_Click(object sender, RoutedEventArgs e)
        {
            ConsultaCliente vista = new ConsultaCliente();
            vista.Show();
            Close();
        }
    }
}
