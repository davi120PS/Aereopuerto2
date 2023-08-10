using Aereopuerto2.Contex;
using Aereopuerto2.Entities;
using Aereopuerto2.Services;
using Microsoft.Extensions.Logging;
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
        GerenteRServices services3 = new GerenteRServices();
        private void BtnAceptar_Click(object sender, RoutedEventArgs e)
        {
            if (CbHoraConductor != null && CbHoraHotel != null && CbNombreConductor != null)
            {
                int userId = Convert.ToInt32(txtNoReserva.Text);
                Cliente cliente = new Cliente()
                {
                    PKCliente = userId,
                    Estatus = "En curso",
                    Solicitud = "Listo",
                    //FKEmpleado = int.Parse(CbNombreConductor.SelectedValue.ToString()),
                    FKEmpleado = GetConductorById(),
                    HoraHotel = CbHoraHotel.Text,
                    HoraConductor = CbHoraConductor.Text
                };
                services3.UpdateReserva(cliente);
                MessageBox.Show("Reserva Confirmada");
                MenuGerenteR vista = new MenuGerenteR();
                vista.Show();
                Close();
            }
            else
                MessageBox.Show("Rellena los campos faltantes");
        }
        private void BtnCancelarR_Click(object sender, RoutedEventArgs e)
        {
            int userId = Convert.ToInt32(txtNoReserva.Text);
            Cliente cliente = new Cliente()
            {
                PKCliente = userId,
                Estatus = "Cancelada",
                Solicitud = "Listo"
            };
            services3.CancelarReserva(cliente);
            services2.DeleteCliente(userId);
            MessageBox.Show("Reserva Cancelada");
            LimpiarCampos();
            MenuGerenteR vista = new MenuGerenteR();
            vista.Show();
            Close();
        }
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
            txtEstatus.Text = cliente.Estatus.ToString();
            txtSolicitud.Text = cliente.Solicitud.ToString();
            CbHoraConductor.Text = cliente.HoraConductor.ToString();
            CbHoraHotel.Text = cliente.HoraHotel.ToString();
            CbNombreConductor.Text = cliente.FKEmpleado.ToString();
            //SolicitudCliente();
            BotonesVisibles();
        }
        /*public void SolicitudCliente()
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
        }*/
        public int GetConductorById()
        {
            string nombrec = CbNombreConductor.Text;
            using (var context = new ApplicationDbContext())
            {
                // Suponiendo que DbSet "Empleados" representa la tabla de ventas en la base de datos.
                var conductorbd = context.Empleado.FirstOrDefault(x => x.Nombre == nombrec);
                return conductorbd.PKEmpleado;
            }
        }
        public void BotonesVisibles()
        {
            if (txtSolicitud.Text != "")
            {
                if (txtSolicitud.Text == "Aceptable" || txtSolicitud.Text == "Modificable")
                {
                    BtnCancelarR.Visibility = Visibility.Collapsed;
                    //txtEstatus.Text = "En espera";
                }
                else if (txtSolicitud.Text == "Cancelable")
                {
                    BtnAceptar.Visibility = Visibility.Collapsed;
                    //txtEstatus.Text = "En espera";
                }
            }
        }
        public void GetConductores()
        {
            CbNombreConductor.ItemsSource = services.GetConductores();
            CbNombreConductor.DisplayMemberPath = "Nombre";
            CbNombreConductor.SelectedValuePath = "PKEmpleado";
        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            MenuGerenteR vista = new MenuGerenteR();
            vista.Show();
            Close();
        }
        public void LimpiarCampos()
        {
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
    }
}
