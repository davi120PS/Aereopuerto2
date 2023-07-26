using Aereopuerto2.Contex;
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

namespace Aereopuerto2.VistaSistema
{
    /// <summary>
    /// Lógica de interacción para ListaEmpleados.xaml
    /// </summary>
    public partial class ListaEmpleados : Window
    {
        public ListaEmpleados()
        {
            InitializeComponent();
        }
        EmpleadoServices services = new EmpleadoServices();
        private void BtnAddEmp_Click(object sender, RoutedEventArgs e)
        {
            if (txtPKEmpleado.Text == "")
            {
                if (txtNombre.Text != "" || CbxPuesto.Text != "" || txtMatricula.Text != "" || txtContraseña.Text != "" || txtCorreo.Text != "" || CbxSexo.Text != null)
                {
                    Empleado empleado = new Empleado();
                    empleado.Nombre = txtNombre.Text;
                    empleado.Puesto = CbxPuesto.Text;
                    empleado.Matricula = txtMatricula.Text;
                    empleado.Contraseña = txtContraseña.Text;
                    empleado.Correo = txtCorreo.Text;
                    empleado.Sexo = CbxSexo.Text;
                    services.Add(empleado);
                    MessageBox.Show("Empleado registrado");
                    GetEmpleadosTable();
                    txtPKEmpleado.Clear();
                    txtNombre.Clear();
                    CbxPuesto.SelectedItem = null;
                    txtMatricula.Clear();
                    txtContraseña.Clear();
                    txtCorreo.Clear();
                    CbxSexo.SelectedItem = null;
                }
                else
                    MessageBox.Show("Faltan datos por llenar");
            }
            /*else
            {
                int Id = Convert.ToInt32(txtPKEmpleado.Text);
                Empleado empleado = new Empleado()
                {
                    PKEmpleado = Id,
                    Nombre = txtNombre.Text,
                    Puesto = CbxPuesto.Text,
                    Matricula = txtMatricula.Text,
                    Contraseña = txtContraseña.Text,
                    Correo = txtCorreo.Text,
                    Sexo = CbxSexo.Text
                };
                services.Update(empleado);
                MessageBox.Show("Empleado actualizado");
                //GetEmpleadosTable();
                txtPKEmpleado.Clear();
                txtNombre.Clear();
                CbxPuesto.SelectedItem = null;
                txtMatricula.Clear();
                txtContraseña.Clear();
                txtCorreo.Clear();
                CbxSexo.SelectedItem = null;
            }*/
        }
        public void EditItem(object sender, RoutedEventArgs e)
        {
            Empleado empleados = new Empleado();
            empleados = (sender as FrameworkElement).DataContext as Empleado;
            txtPKEmpleado.Text = empleados.PKEmpleado.ToString();
            txtNombre.Text = empleados.Nombre.ToString();
            CbxPuesto.Text = empleados.Puesto.ToString();
            txtMatricula.Text = empleados.Matricula.ToString();
            txtContraseña.Text = empleados.Contraseña.ToString();
            txtCorreo.Text = empleados.Correo.ToString();
            CbxSexo.Text = empleados.Sexo.ToString();
        }
        private void BtnDarBaja_Click(object sender, RoutedEventArgs e)
        {
            if (txtPKEmpleado.Text == "")
            {
                MessageBox.Show("Selecciona un usuario");
            }
            else
            {
                using (var _context = new ApplicationDbContext())
                {
                    int Id = Convert.ToInt32(txtPKEmpleado.Text);
                    Empleado empleado = new Empleado()
                    {
                        PKEmpleado = Id,
                        Nombre = txtNombre.Text,
                        Puesto = CbxPuesto.Text,
                        Matricula = txtMatricula.Text,
                        Contraseña = txtContraseña.Text,
                        Sexo = CbxSexo.Text,
                        Correo = txtCorreo.Text
                    };
                    services.Update(empleado);
                    MessageBox.Show("Empleado dado de baja");
                    GetEmpleadosTable();
                    txtPKEmpleado.Clear();
                    txtNombre.Clear();
                    CbxPuesto.SelectedItem = null;
                    txtMatricula.Clear();
                    txtContraseña.Clear();
                    txtCorreo.Clear();
                    CbxSexo.SelectedItem = null;
                }
            }
        }
        public void GetEmpleadosTable()
        {
            TablaEmpleado.ItemsSource = services.GetEmpleados();
        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            MenuSistemas admin = new MenuSistemas();
            admin.Show();
            Close();
        }
        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            txtPKEmpleado.Clear();
            txtNombre.Clear();
            CbxPuesto.SelectedItem = null;
            txtMatricula.Clear();
            txtContraseña.Clear();
            txtCorreo.Clear();
            CbxSexo.SelectedItem = null;
        }
    }
}