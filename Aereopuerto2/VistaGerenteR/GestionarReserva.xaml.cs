using Aereopuerto2.Entities;
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
    /// Lógica de interacción para GestionarReserva.xaml
    /// </summary>
    public partial class GestionarReserva : Window
    {
        public GestionarReserva()
        {
            InitializeComponent();
            GetConductores();
        }
        EmpleadoServices services = new EmpleadoServices();

        public void GetReserva(object sender, RoutedEventArgs e)
        {
            Cliente cliente = new Cliente();

            cliente = (sender as FrameworkElement).DataContext as Cliente;
            txtNoReserva.Text = cliente.PKCliente.ToString();
            txtSolicitud.Text = cliente.Solicitud.ToString();
            txtNombre.Text = cliente.Nombre.ToString();
            txtApellido.Text = cliente.Apellido.ToString();
            txtEdad.Text = cliente.Edad.ToString();
            txtINE.Text = cliente.INE.ToString();
            txtTelefono.Text = cliente.Telefono.ToString();
            txtCorreo.Text = cliente.Correo.ToString();
            cbxServicio.Text = cliente.TipoServicio.ToString();
            txtPasajeros.Text = cliente.Pasajeros.ToString();
        }
        public void SolicitudCliente()
        {
            switch (txtSolicitud.Text)
            {
                case "Aceptable":
                    BtnModificar.IsEnabled = false;
                    BtnCancelarR.IsEnabled = false;
                    break;
                case "Modificable":
                    BtnAceptar.IsEnabled = false;
                    BtnCancelarR.IsEnabled = false;
                    break;
                case "Cancelabre":
                    BtnModificar.IsEnabled = false;
                    BtnAceptar.IsEnabled = false;
                    break;
            }
        }
        public void GetConductores()
        {
            CbNombreConductor.ItemsSource = services.GetConductores();
            CbNombreConductor.DisplayMemberPath = "Nombre";
            CbNombreConductor.SelectedValuePath = "PKConductor";
        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            MenuGerenteR vista = new MenuGerenteR();
            vista.Show();
            Close();
        }
    }
}
