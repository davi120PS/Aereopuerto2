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

namespace Aereopuerto2.VistaConductor
{
    /// <summary>
    /// Lógica de interacción para ListaServicios.xaml
    /// </summary>
    public partial class ListaServicios : Window
    {
        public ListaServicios()
        {
            InitializeComponent();
            services.GetClientes();
        }
        EmpleadoServices services = new EmpleadoServices();

        private void ClientesTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
