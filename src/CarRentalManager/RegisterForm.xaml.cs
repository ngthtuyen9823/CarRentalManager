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

namespace CarRentalManager
{
    /// <summary>
    /// Interaction logic for RegisterForm.xaml
    /// </summary>
    public partial class RegisterForm : Window
    {
        public RegisterForm(string id)
        {
            MessageBox.Show(id);
            InitializeComponent();
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e) => DragMove();

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
