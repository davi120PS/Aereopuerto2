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
    /// Lógica de interacción para HorariosConductores.xaml
    /// </summary>
    public partial class HorariosConductores : Window
    {
        public HorariosConductores()
        {
            InitializeComponent();
            GetHorarioTable();
        }
        EmpleadoServices services = new EmpleadoServices();
        MasServices masServices = new MasServices();
        ConductorSevices conductorSevices = new ConductorSevices();
        public void GetHorarioTable()
        {
            HorariosTable.ItemsSource = services.GetSoloConductor();
        }
        public void EditItem(object sender, RoutedEventArgs e)
        {
            Empleado horario = new Empleado();
            horario = (sender as FrameworkElement).DataContext as Empleado;
            txtPKEmpleado.Text = horario.PKEmpleado.ToString();
            CbEstatus.Text = horario.Estatus.ToString();
        }

        private void BtnEstatus_Click(object sender, RoutedEventArgs e)
        {
            if (txtPKEmpleado.Text != "")
            {
                int horarioId = Convert.ToInt32(txtPKEmpleado.Text);

                Empleado horario = new Empleado()
                {
                    PKEmpleado = horarioId,
                    Estatus = CbEstatus.Text,
                };
                MessageBox.Show("Estatus actualizado");
                conductorSevices.Update(horario);
                txtPKEmpleado.Clear();
                CbEstatus.Text = "";
                GetHorarioTable();
            }
        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            ListaServicios listaServicios = new ListaServicios();
            listaServicios.Show();
            Close();
        }
    }
}
