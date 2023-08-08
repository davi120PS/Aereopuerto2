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
    /// Lógica de interacción para AsignarHorariosC.xaml
    /// </summary>
    public partial class AsignarHorariosC : Window
    {
        public AsignarHorariosC()
        {
            InitializeComponent();
            GetHorarioTable();
        }
        MasServices masServices = new MasServices();
        EmpleadoServices empleadoservices = new EmpleadoServices();
        private void BtnAsignar_Click(object sender, RoutedEventArgs e)
        {
            if (txtPKEmpleado.Text != "")
            {
                int horarioId = Convert.ToInt32(txtPKEmpleado.Text);

                Empleado horario = new Empleado()
                {
                    PKEmpleado = horarioId,
                    Horarios = CbHorario.Text
                };
                MessageBox.Show("Horario asignado");
                masServices.UpdateHorario(horario);
                txtPKEmpleado.Clear();
                CbHorario.Text = "";
                GetHorarioTable();
            }
            else
                MessageBox.Show("Selecciona a un conductor");
        }
        public void GetHorarioTable()
        {
            HorariosTable.ItemsSource = empleadoservices.GetConductores();
        }
        public void GetHorario()
        {
            CbHorario.ItemsSource = empleadoservices.GetHorarios();
            CbHorario.DisplayMemberPath = "Horarios";
            CbHorario.SelectedValuePath = "PKEmpleado";
        }
        public void EditItem(object sender, RoutedEventArgs e)
        {
            Empleado horario = new Empleado();
            horario = (sender as FrameworkElement).DataContext as Empleado;
            txtPKEmpleado.Text = horario.PKEmpleado.ToString();
            CbHorario.Text = horario.Horarios.ToString();
        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            MenuSistemas menusistemas = new MenuSistemas();
            menusistemas.Show();
            Close();
        }
    }
}