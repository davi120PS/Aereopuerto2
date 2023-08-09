﻿using System;
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
    /// Lógica de interacción para MenuGerenteR.xaml
    /// </summary>
    public partial class MenuGerenteR : Window
    {
        public MenuGerenteR()
        {
            InitializeComponent();
        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Login vista = new Login();
            vista.Show();
            Close();
        }
        private void BtnReservas_Click(object sender, RoutedEventArgs e)
        {
            ReservaGerenteR vista = new ReservaGerenteR();
            vista.Show();
            Close();
        }
        private void BtnConductores_Click(object sender, RoutedEventArgs e)
        {
            HorariosConductor horarios = new HorariosConductor();
            horarios.Show();
            Close();
        }
    }
}