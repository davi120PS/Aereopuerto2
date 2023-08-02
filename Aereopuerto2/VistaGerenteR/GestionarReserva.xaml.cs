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
        ClienteServices services2 = new ClienteServices();

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
                    BtnCancelarR.IsEnabled = false;
                    txtEstatus.Text = "En espera";
                    break;
                case "Modificable":
                    BtnCancelarR.IsEnabled = false;
                    txtEstatus.Text = "En espera";
                    break;
                case "Cancelar":
                    BtnAceptar.IsEnabled = false;
                    txtEstatus.Text = "En espera";
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

        private void BtnCancelarR_Click(object sender, RoutedEventArgs e)
        {
            int userId = Convert.ToInt32(txtNoReserva.Text);
            Cliente cliente = new Cliente();
            cliente.PKCliente = userId;
            services2.DeleteCliente(userId);
            MessageBox.Show("Reserva Cancelada");
            txtSolicitud.Clear();
            txtNoReserva.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtEdad.Clear();
            txtINE.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            cbxServicio.SelectedItem = null;
            CbHoraConductor.SelectedItem = null;
            CbHoraHotel.SelectedItem = null;
            txtPasajeros.Clear();
            CbNombreConductor.SelectedItem = null;
            txtEstatus.Clear();
        }

        private void BtnAceptar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
