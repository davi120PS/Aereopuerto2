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

namespace Aereopuerto2.VistaCliente
{
    /// <summary>
    /// Lógica de interacción para ConsultaCliente.xaml
    /// </summary>
    public partial class ConsultaCliente : Window
    {
        public ConsultaCliente()
        {
            InitializeComponent();
        }
        ClienteServices services = new ClienteServices();
        private void BtnConsultar_Click(object sender, RoutedEventArgs e)
        {
            if(txtNoReserva.Text != "")
            {
                int NoReserva = int.Parse(txtNoReserva.Text);
                Cliente empleado = services.Read(NoReserva);
                if (empleado != null)
                {
                    txtNombre.Text = empleado.Nombre;
                    txtApellido.Text = empleado.Apellido;
                    txtEdad.Text = empleado.Edad.ToString();
                    txtINE.Text = empleado.INE;
                    txtTelefono.Text = empleado.Telefono.ToString();
                    txtCorreo.Text = empleado.Correo;
                    cbxServicio.Text = empleado.TipoServicio;
                    txtPasajeros.Text = empleado.Pasajeros.ToString();
                    txtHoraConductor.Text = empleado.HoraConductor.ToString();
                    txtHoraHotel.Text = empleado.HoraHotel.ToString();
                    txtNombreConductor.Text = services.GetConductores(int.Parse(empleado.FKEmpleado.ToString()));

                    /*switch (empleado.Solicitud)
                    {
                        case "Aceptable":
                            txtEstatus.Text = "En espera";
                            break;
                        case "Modificable":
                            txtEstatus.Text = "En espera";
                            break;
                        case "Cancelar":
                            txtEstatus.Text = "En espera";
                            break;
                        case "Listo":
                            txtEstatus.Text = "Aceptada";
                            break;
                    }*/
                }
                else
                {
                    MessageBox.Show("Reserva no encontrada");
                    LimpiarCampos();
                }
            }
            else
                MessageBox.Show("Ingresa el No. de Reserva");
        }
        private void BtnModificar_Click(object sender, RoutedEventArgs e)
        {
            int Id = Convert.ToInt32(txtNoReserva.Text);
            Cliente usuario = new Cliente()
            {
                PKCliente = Id,
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Edad = int.Parse(txtEdad.Text),
                INE = txtINE.Text,
                Telefono = int.Parse(txtTelefono.Text),
                Correo = txtCorreo.Text,
                TipoServicio = cbxServicio.Text,
                Pasajeros = int.Parse(txtPasajeros.Text),
                Estatus = "Por confirmar modificación",
                Solicitud = "Modificable"
            };
            services.Update(usuario);
            MessageBox.Show("Solicitud de modificacion enviada");
            LimpiarCampos();
            MainWindow interfaz = new();
            interfaz.Show();
            Hide();
        }
        private void BtnCancelarR_Click(object sender, RoutedEventArgs e)
        {
            int Id = Convert.ToInt32(txtNoReserva.Text);
            Cliente usuario = new Cliente()
            {
                PKCliente = Id,
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Edad = int.Parse(txtEdad.Text),
                INE = txtINE.Text,
                Telefono = int.Parse(txtTelefono.Text),
                Correo = txtCorreo.Text,
                TipoServicio = cbxServicio.Text,
                Pasajeros = int.Parse(txtPasajeros.Text),
                Estatus = "Por confirmar cancelación",
                Solicitud = "Cancelar"
            };
            services.Update(usuario);
            MessageBox.Show("Solicitud de cancelacion enviada");
            LimpiarCampos();
            MainWindow interfaz = new();
            interfaz.Show();
            Hide();
        }
        private void BtnRegresar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow interfaz = new ();
            interfaz.Show();
            Close();
        }
        public void LimpiarCampos()
        {
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtEdad.Text = string.Empty;
            txtINE.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            cbxServicio.Text = string.Empty;
            txtPasajeros.Text = string.Empty;
        }
    }
}
