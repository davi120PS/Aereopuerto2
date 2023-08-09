using Aereopuerto2.Contex;
using Aereopuerto2.Entities;
using Aereopuerto2.Services;
using Aereopuerto2.VistaConductor;
using Org.BouncyCastle.Asn1.Ocsp;
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
            GetConductores();
        }
        EmpleadoServices services = new EmpleadoServices();
        ConductorSevices conductorSevices = new ConductorSevices();
        GerenteRServices services2 = new GerenteRServices();
        private void BtnEnviar_Click(object sender, RoutedEventArgs e)
        {
            if (txtPKChat.Text == "")
            {
                if (CbConductores.Text != null)
                {
                    Chat chat = new Chat()
                    {
                        Mensaje = txtMensaje.Text,
                        FKEmpleado = int.Parse(CbConductores.SelectedValue.ToString()),
                        Gerente = GetEmpleadoActivo(),
                    };
                    services2.AddChatGerente(chat);
                    MessageBox.Show("Mensaje enviado");
                    txtMensaje.Clear();
                    GetChatTable();
                }
                else
                    MessageBox.Show("Selecciona un conductor");
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
        public string GetEmpleadoActivo()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Empleado empl = _context.Empleado.FirstOrDefault(x => x.Conexion == 1);
                    return empl.Nombre;
                }
            }
            catch (Exception ex)
            {

                throw new Exception("ERROR: " + ex.Message);
            }
        }
        public void GetChatTable()
        {
            ChatTable.ItemsSource = services2.GetChatGerente();
        }
        public void GetConductores()
        {
            CbConductores.ItemsSource = services.GetConductores();
            CbConductores.DisplayMemberPath = "Nombre";
            CbConductores.SelectedValuePath = "PKEmpleado";
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
            if (txtPKChat.Text != "")
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
            else
            {
                MessageBox.Show("Selecciona un mensaje");
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            HorariosConductor listaServicios = new HorariosConductor();
            listaServicios.Show();
            Close();
        }
    }
}
