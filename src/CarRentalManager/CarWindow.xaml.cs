﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace CarRentalManager
{
    /// <summary>
    /// Interaction logic for CarWindow.xaml
    /// </summary>
    public partial class CarWindow : Window
    {

        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        public CarWindow()
        {
            InitializeComponent();


        }
    
    }
}