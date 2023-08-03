using Aereopuerto2.Contex;
using Aereopuerto2.Entities;
using Aereopuerto2.Services;
using Aereopuerto2.VistaConductor;
using Aereopuerto2.VistaGerenteR;
using Aereopuerto2.VistaSistema;
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

namespace Aereopuerto2
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }
        private void BtnRegresar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow interfaz = new();
            interfaz.Show();
            Close();
        }
        EmpleadoServices services = new EmpleadoServices();
        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            string user = txtMatricula.Text;
            string pass = Password.Password;
            var response = services.Login(user, pass);

            if (txtMatricula.Text != "" && Password.Password != "")
            {
                if (response != null)
                {
                    switch (response.Puesto)
                    {
                        case "Reservas":
                            MenuGerenteR menu = new MenuGerenteR();
                            menu.Show();
                            Close();
                            break;
                        case "Conductor":
                            try
                            {
                                using (var _context = new ApplicationDbContext())
                                {
                                    Empleado empleado = new Empleado()
                                    {
                                        Conexion = 1
                                    };
                                }
                            }
                            catch (Exception ex)
                            {
                                throw new Exception ("Error" + ex.Message);
                            }
                            ListaServicios listaServicios = new ListaServicios();
                            listaServicios.Show();
                            Close();
                            break;
                        case "Sistema":
                            MenuSistemas sistema = new MenuSistemas();
                            sistema.Show();
                            Close();
                            break;
                    }
                }
                else
                    MessageBox.Show("No existe empleado");
            }
            else
                MessageBox.Show("Ingresa los datos");
        }
    }
}
