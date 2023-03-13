using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for RegisterForm.xaml
    /// </summary>
    public partial class RegisterForm : Window
    {
        public RegisterForm()
        {
            InitializeComponent();
        }
        public RegisterForm(string id)
        {           
            InitializeComponent();
            lblIDXe.Content = "ID XE : " + id;
        }

        public string ID { get; set; }
        private void RegisterForm_Load(object sender, EventArgs e)
        {
            lblIDXe.Content = ID;
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e) => DragMove();

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
