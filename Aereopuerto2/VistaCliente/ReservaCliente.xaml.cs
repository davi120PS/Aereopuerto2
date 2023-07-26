using Aereopuerto2.Entities;
using Aereopuerto2.Services;
using Aereopuerto2.VistaGerenteR;
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
using System.Windows.Media.TextFormatting;
using System.Windows.Shapes;

namespace Aereopuerto2.VistaCliente
{
    /// <summary>
    /// Lógica de interacción para ReservaCliente.xaml
    /// </summary>
    public partial class ReservaCliente : Window
    {
        public ReservaCliente()
        {
            InitializeComponent();
        }
        ClienteServices services = new ClienteServices();
        private void BtnAceptar_Click(object sender, RoutedEventArgs e)
        {
            Cliente cliente = new Cliente()
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Edad = int.Parse(txtEdad.Text),
                INE = txtINE.Text,
                Telefono = int.Parse(txtTelefono.Text),
                Correo = txtCorreo.Text,
                TipoServicio = cbxServicio.Text,
                Pasajeros = int.Parse(txtPasajeros.Text)
            };
            if (!string.IsNullOrEmpty(txtNombre.Text) || !string.IsNullOrEmpty(txtApellido.Text) || !string.IsNullOrEmpty(txtApellido.Text))
            {
                services.Add(cliente);
                txtNombre.Clear();
                txtApellido.Clear();
                txtEdad.Clear();
                txtINE.Clear();
                txtTelefono.Clear();
                txtCorreo.Clear();
                cbxServicio.Items.Clear();
                txtPasajeros.Clear();
                txtNoReserva.Clear();
                MessageBox.Show("Los datos han sido agregados correctamente");
            }
            else
                MessageBox.Show("Los datos no sido agregados correctamente");
            MessageBox.Show("Reserva generada exitosamente");
            MainWindow interfaz = new MainWindow();
            interfaz.Show();
            Close();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow interfaz = new ();
            interfaz.Show();
            Close();
        }
    }
}
