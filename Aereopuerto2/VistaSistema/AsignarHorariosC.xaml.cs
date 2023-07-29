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
            if (txtPKHorario.Text == "")
            {
                Horario horario = new Horario()
                {
                    Horarios = CbHorario.Text,
                    Conductores = CbConductor.Text,
                    Estatus = "",
                    FKConductor = int.Parse(CbConductor.SelectedValue.ToString())
                };

                masServices.AsignarHorario(horario);
                MessageBox.Show("Horario asignado");
                txtPKHorario.Clear();
                CbConductor.Text = "";
                CbHorario.Text = "";
            }
            else
            {
                int horarioId = Convert.ToInt32(txtPKHorario.Text);

                Horario horario = new Horario()
                {
                    PKHorario = horarioId,
                    Horarios = CbHorario.Text,
                    Conductores = CbConductor.Text,
                    FKConductor = int.Parse(CbConductor.SelectedValue.ToString())
                };
                MessageBox.Show("Horario actualizado");
                masServices.Update(horario);
                txtPKHorario.Clear();
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
            Horario horario = new Horario();
            horario = (sender as FrameworkElement).DataContext as Horario;
            txtPKHorario.Text = horario.PKHorario.ToString();
            CbHorario.Text = horario.Horarios.ToString();
            CbConductor.Text = horario.Conductores.ToString();
        }
        public void DeleteItem(object sender, RoutedEventArgs e)
        {
            int horarioId = Convert.ToInt32(txtPKHorario.Text);
            Horario horario = new Horario();
            horario.PKHorario = horarioId;
            masServices.DeleteHorario(horarioId);
            MessageBox.Show("Horario eliminado");
            txtPKHorario.Clear();
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
