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
                }
                else
                {
                    MessageBox.Show("Reserva no encontrada");
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
                Solicitud = "Modificable"
            };
            services.Update(usuario);
            MessageBox.Show("Cliente actualizado");
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
                Solicitud = "Cancelar"
            };
            MessageBox.Show("Cliente actualizado");
            services.Update(usuario);
        }
        private void BtnRegresar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow interfaz = new ();
            interfaz.Show();
            Close();
        }

        private void btnChat_Click(object sender, RoutedEventArgs e)
        {
            VChatCliente cliente = new VChatCliente();
            cliente.Show();
            Close();
        }
    }
}
