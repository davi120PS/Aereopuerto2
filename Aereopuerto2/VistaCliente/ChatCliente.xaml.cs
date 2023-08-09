using Aereopuerto2.Entities;
using Aereopuerto2.Services;
using Aereopuerto2.VistaConductor;
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
    /// Lógica de interacción para ChatCliente.xaml
    /// </summary>
    public partial class ChatCliente : Window
    {
        public ChatCliente()
        {
            InitializeComponent();
            GetChatTable();
            GetConductores();
        }
        EmpleadoServices services = new EmpleadoServices();
        ConductorSevices conductor = new ConductorSevices();
        ClienteServices service1 = new ClienteServices();
        private void BtnEnviar_Click(object sender, RoutedEventArgs e)
        {
            if (txtPKChat.Text == "")
            {
                int i = 0; i++;
                Chat chat = new Chat()
                {
                    Mensaje = txtMensaje.Text,
                    FKEmpleado = int.Parse(CbConductor.SelectedValue.ToString()),
                    FKCliente = i,
                    Remitente = "",
                };
                conductor.AddChat(chat);
                //MessageBox.Show("Mensaje enviado");
                txtMensaje.Clear();
                GetChatTable();
            }
            else
            {
                int chatId = Convert.ToInt32(txtPKChat.Text);
                Chat chat = new Chat()
                {
                    PKChat = chatId,
                    Mensaje = txtMensaje.Text,
                };
                //MessageBox.Show("Mensaje editado");
                conductor.UpdateMessage(chat);
                txtMensaje.Clear();
                GetChatTable();
            }
        }
        public void GetChatTable()
        {
            ChatTable.ItemsSource = conductor.GetChat().Where(x => x.FKCliente != null);
        }
        public void GetConductores()
        {
            CbConductor.ItemsSource = services.GetConductores().Where(x => x.Conexion == 1);
            CbConductor.DisplayMemberPath = "Nombre";
            CbConductor.SelectedValuePath = "PKEmpleado";
        }
        public void EditItem(object sender, RoutedEventArgs e)
        {
            Chat chat = new Chat();
            chat = (sender as FrameworkElement).DataContext as Chat;
            txtPKChat.Text = chat.PKChat.ToString();
            txtMensaje.Text = chat.Mensaje.ToString();
        }
        public void DeleteItem(object sender, RoutedEventArgs e)
        {
            int chatId = Convert.ToInt32(txtPKChat.Text);
            Chat chat = new Chat();
            chat.PKChat = chatId;
            conductor.DeleteChat(chatId);
            MessageBox.Show("Mensaje eliminado");
            txtPKChat.Clear();
            txtMensaje.Clear();
            GetChatTable();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            ConsultaCliente listaServicios = new ConsultaCliente();
            listaServicios.Show();
            Close();
        }

        private void CbClientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
