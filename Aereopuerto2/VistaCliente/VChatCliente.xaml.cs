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
    /// Lógica de interacción para VChatCliente.xaml
    /// </summary>
    public partial class VChatCliente : Window
    {
        public VChatCliente()
        {
            InitializeComponent();
            GetChatTable();
            GetConductor();
        }
        ConductorSevices conductorSevices = new ConductorSevices();
        EmpleadoServices services = new EmpleadoServices();
        ClienteServices services2 = new ClienteServices();
        private void BtnEnviar_Click(object sender, RoutedEventArgs e)
        {
            if (txtPKChat.Text == "")
            {
                Chat chat = new Chat()
                {
                    Mensaje = txtMensaje.Text,
                    FKEmpleado = int.Parse(CbConductor.SelectedValue.ToString())
                };

                conductorSevices.AddChat(chat);
                MessageBox.Show("Mensaje enviado");
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
                MessageBox.Show("Mensaje editado");
                conductorSevices.UpdateMessage(chat);
                txtMensaje.Clear();
                GetChatTable();
            }
        }
        public void GetChatTable()
        {
            ChatTable.ItemsSource = conductorSevices.GetChat();
        }
        public void GetConductor()
        {
            CbConductor.ItemsSource = services.GetConductores();
            CbConductor.DisplayMemberPath = "Nombre";
            CbConductor.SelectedValuePath = "PKCliente";
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
            conductorSevices.DeleteChat(chatId);
            MessageBox.Show("Mensaje eliminado");
            txtPKChat.Clear();
            txtMensaje.Clear();
            GetChatTable();

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            ConsultaCliente consulta = new ConsultaCliente();
            consulta.Show();
            Close();
        }
    }
}
