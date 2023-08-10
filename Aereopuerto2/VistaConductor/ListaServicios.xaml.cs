using Aereopuerto2.Contex;
using Aereopuerto2.Entities;
using Aereopuerto2.Services;
using MySql.Data.MySqlClient;
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

namespace Aereopuerto2.VistaConductor
{
    /// <summary>
    /// Lógica de interacción para ListaServicios.xaml
    /// </summary>
    public partial class ListaServicios : Window
    {
        public ListaServicios()
        {
            InitializeComponent();
            GetClientesTable();
        }
        EmpleadoServices services = new EmpleadoServices();
        ConductorSevices conductorServices = new ConductorSevices();
        MasServices masServices = new MasServices();
        public void GetClientesTable()
        {
            ClientesTable.ItemsSource = services.GetClientes();
        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    //Empleado empleado = new Empleado();
                    Empleado update = _context.Empleado.FirstOrDefault(x => x.Puesto == "Conductor" && x.Conexion == 1);
                    update.PKEmpleado = update.PKEmpleado;
                    update.Conexion = 0;
                    services.UpdateEstado(update);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error" + ex.Message);
            }
            Login login = new Login();
            login.Show();
            Close();
        }

        private void BtnHorario_Click(object sender, RoutedEventArgs e)
        {
            HorariosConductores horarios = new HorariosConductores();
            horarios.Show();
            Close();
        }
        private void ChatCliente_Click(object sender, RoutedEventArgs e)
        {
            VistaChat chat = new VistaChat();
            chat.Show();
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ChatGerenteR_Conductor gerenteR_Conductor = new();
            gerenteR_Conductor.Show();
            Close();
        }
    }
}
