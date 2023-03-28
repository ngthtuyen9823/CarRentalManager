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

namespace CarRentalManager
{
    /// <summary>
    /// Interaction logic for LoginForm.xaml
    /// </summary>
    public partial class LoginForm : Window
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        private void textEmail_MouseDown(object sender, MouseEventArgs e)
        {
            txtEmail.Focus();
        }
        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            if (true)
            {
                if (!string.IsNullOrEmpty(txtEmail.Text) && txtEmail.Text.Length > 0) 
                {
                    textEmail.Visibility = Visibility.Collapsed;
                }
                else
                {
                    textEmail.Visibility = Visibility.Visible;
                }    
            }
        }
        private void textPassword_MouseDown(object sender, MouseEventArgs e)
        {
            txtPassword.Focus();
        }
        private void txtPassword_PasswordChanged(object sender, EventArgs e)
        {
            if (true)
            {
                if (!string.IsNullOrEmpty(txtPassword.Password) && txtPassword.Password.Length > 0)
                {
                    textPassword.Visibility = Visibility.Collapsed;
                }
                else
                {
                    textPassword.Visibility = Visibility.Visible;
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEmail.Text) && !string.IsNullOrEmpty(txtPassword.Password))
            {
                MessageBox.Show("Successfully Signed in");
            }
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
