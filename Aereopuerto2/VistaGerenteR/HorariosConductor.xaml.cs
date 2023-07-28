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

namespace Aereopuerto2.VistaGerenteR
{
    /// <summary>
    /// Lógica de interacción para HorariosConductor.xaml
    /// </summary>
    public partial class HorariosConductor : Window
    {
        public HorariosConductor()
        {
            InitializeComponent();
            GetHorarioTable();
        }
        MasServices masServices = new MasServices();
        public void GetHorarioTable()
        {
            HorariosTable.ItemsSource = masServices.GetHorarios();
        }
    }
}
