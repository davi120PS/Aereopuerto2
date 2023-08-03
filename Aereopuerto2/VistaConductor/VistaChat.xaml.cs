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

namespace Aereopuerto2.VistaConductor
{
    /// <summary>
    /// Lógica de interacción para VistaChat.xaml
    /// </summary>
    public partial class VistaChat : Window
    {
        public VistaChat()
        {
            InitializeComponent();
            GetCbCliente();
            GetChatTable();
        }
        ConductorSevices conductorSevices = new ConductorSevices();
        EmpleadoServices services = new EmpleadoServices();
        private void BtnEnviar_Click(object sender, RoutedEventArgs e)
        {
            if (txtPKChat.Text == "")
            {
                Chat chat = new Chat()
                {
                    Mensaje = txtMensaje.Text,
                    FKCliente = int.Parse(CbCliente.SelectedValue.ToString())
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
        public void GetCbCliente()
        {
            CbCliente.ItemsSource = services.GetClientes();
            CbCliente.DisplayMemberPath = "Nombre";
            CbCliente.SelectedValuePath = "PKCliente";
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
