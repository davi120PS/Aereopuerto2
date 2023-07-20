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

namespace Aereopuerto2.Vistas
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }
        private void BtnRegresar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow interfaz = new();
            interfaz.Show();
            Close();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                MessageBox.Show("Sesión exitosa");
                /*MainWindow interfaz = new();
                interfaz.Show();
                Close();*/
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error " + ex.Message);
            }
        }
    }
}
