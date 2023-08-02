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
            GetConductores();
        }
        MasServices masServices = new MasServices();
        EmpleadoServices empleadoservices = new EmpleadoServices();
        private void BtnAsignar_Click(object sender, RoutedEventArgs e)
        {
            if (txtPKConductor.Text == "")
            {
                Conductor conductor = new Conductor()
                {
                    PKConductor = int.Parse(CbConductor.SelectedValue.ToString()),
                    Horarios = CbHorario.Text,
                    Estatus = "",
                };

                masServices.AsignarHorario(conductor);
                MessageBox.Show("Horario asignado");
                txtPKConductor.Clear();
                CbConductor.Text = "";
                CbHorario.Text = "";
            }
            else
            {
                int horarioId = Convert.ToInt32(txtPKConductor.Text);

                Conductor conductor = new Conductor()
                {
                    PKConductor = horarioId,
                    Horarios = CbHorario.Text,
                    Estatus = "",
                };
                MessageBox.Show("Horario actualizado");
                masServices.Update(conductor);
                txtPKConductor.Clear();
                CbConductor.Text = "";
                CbHorario.Text = "";
                GetHorarioTable();
            }
        }
        public void GetHorarioTable()
        {
            HorariosTable.ItemsSource = masServices.GetHorarios();
        }
        public void GetConductores()
        {
            CbConductor.ItemsSource = empleadoservices.GetConductores();
            CbConductor.DisplayMemberPath = "Nombre";
            CbConductor.SelectedValuePath = "PKEmpleado";
        }
        public void EditItem(object sender, RoutedEventArgs e)
        {
            Conductor horario = new Conductor();
            horario = (sender as FrameworkElement).DataContext as Conductor;
            txtPKConductor.Text = horario.PKConductor.ToString();
            CbHorario.Text = horario.Horarios.ToString();
            CbConductor.Text = horario.PKConductor.ToString();
        }
        public void DeleteItem(object sender, RoutedEventArgs e)
        {
            int horarioId = Convert.ToInt32(txtPKConductor.Text);
            Conductor horario = new Conductor();
            horario.PKConductor = horarioId;
            masServices.DeleteHorario(horarioId);
            MessageBox.Show("Horario eliminado");
            txtPKConductor.Clear();
            CbConductor.Text = "";
            CbHorario.Text = "";
            GetHorarioTable();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            MenuSistemas menusistemas = new MenuSistemas();
            menusistemas.Show();
            Close();
        }
    }
}
