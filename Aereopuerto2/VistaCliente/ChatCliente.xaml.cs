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
        }
        EmpleadoServices services = new EmpleadoServices();
        ConductorSevices conductor = new ConductorSevices();
        private void BtnEnviar_Click(object sender, RoutedEventArgs e)
        {
            if(txtPKChat.Text == "")
            {
                if (CbConductor != null)
                {
                    Chat chat = new Chat()
                    {
                        Mensaje = txtMensaje.Text,
                        FKCliente = 0,
                        FKEmpleado = int.Parse(CbConductor.SelectedValue.ToString())
                    };
                    conductor.AddChat(chat);
                    //MessageBox.Show("Mensaje enviado");
                    txtMensaje.Clear();
                    GetChatTable();
                }
                else
                    MessageBox.Show("Selecciona al conductor");
            }
            else
            {
                if (CbConductor != null)
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
                else
                    MessageBox.Show("Selecciona al conductor");
            }
        }
        public void GetChatTable()
        {
            ChatTable.ItemsSource = conductor.GetChat();
        }
        public void GetConductores()
        {
            CbConductor.ItemsSource = services.GetConductores();
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
            ListaServicios listaServicios = new ListaServicios();
            listaServicios.Show();
            Close();
        }
    }
}
