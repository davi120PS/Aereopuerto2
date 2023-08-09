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

namespace Aereopuerto2.VistaGerenteR
{
    /// <summary>
    /// Lógica de interacción para ChatConductores.xaml
    /// </summary>
    public partial class ChatConductores : Window
    {
        public ChatConductores()
        {
            InitializeComponent();
            GetChatTable();
            //GetGerentes();
        }
        EmpleadoServices services = new EmpleadoServices();
        ConductorSevices conductorSevices = new ConductorSevices();
        private void BtnEnviar_Click(object sender, RoutedEventArgs e)
        {
            if (txtPKChat.Text == "")
            {
                Chat chat = new Chat()
                {
                    Mensaje = txtMensaje.Text,
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
        public void GetComductores()
        {
            CbClientes.ItemsSource = services.GetConductores();
            CbClientes.DisplayMemberPath = "Nombre";
            CbClientes.SelectedValuePath = "PKEmpleado";
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
            ListaServicios listaServicios = new ListaServicios();
            listaServicios.Show();
            Close();
        }
    }
}
