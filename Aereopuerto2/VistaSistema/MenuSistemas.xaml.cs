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

namespace Aereopuerto2.VistaSistema
{
    /// <summary>
    /// Lógica de interacción para MenuSistemas.xaml
    /// </summary>
    public partial class MenuSistemas : Window
    {
        public MenuSistemas()
        {
            InitializeComponent();
        }
        private void BtnListEmpleados_Click(object sender, RoutedEventArgs e)
        {
            ListaEmpleados lista = new ListaEmpleados();
            lista.Show();
            Close();
        }
        private void BtnConductores_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("");
        }
        private void BtnMantenimiento_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Mantenimiento Completado");
        }

        private void BtnRendimiento_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("El rendimiento del sistema es optimo");
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            Close();
        }
    }
}
