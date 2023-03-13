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
using System.Windows.Navigation;
using System.Windows.Shapes;
namespace CarRentalManager
{
    /// <summary>
    /// Interaction logic for CustomCard.xaml
    /// </summary>
    public partial class CustomCard : UserControl
    {
        public CustomCard()
        {
            InitializeComponent();
        }

        /*private void btn_OpenForm(object sender, RoutedEventArgs e)
        {
            var myValue1 = ((Button)sender).Tag;
            var myValue2 = ((Image)sender).Tag;
            RegisterForm win2 = new RegisterForm(myValue.ToString());
            win2.Show();
        }*/

        private void btnLoadRegister_Click(object sender, RoutedEventArgs e)
        {
            var myValue = ((Button)sender).Tag;
            RegisterForm loadRegister = new RegisterForm(myValue.ToString());
            loadRegister.ShowDialog();
        }
    }
}
