﻿using Aereopuerto2.Services;
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
        EmpleadoServices services = new EmpleadoServices();
        public void GetHorarioTable()
        {
            HorariosTable.ItemsSource = services.GetConductores();
        }
        private void ChatConductor_Click(object sender, RoutedEventArgs e)
        {
            ChatConductores chat = new ChatConductores();
            chat.Show();
            Close();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MenuGerenteR menuGerenteR = new MenuGerenteR();
            menuGerenteR.Show();
            Close();
        }
    }
}
