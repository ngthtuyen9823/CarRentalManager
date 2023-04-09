using CarRentalManager.models;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    /// Interaction logic for SupplierView.xaml
    /// </summary>
    public partial class SupplierView : UserControl
    {
        public SupplierView()
        {
            InitializeComponent();
        }
        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            var item = sender as ListViewItem;
            if (item != null && item.IsSelected)
            {
                var selectedCustomer = lsvSupplier.SelectedItems[0] as Supplier;
                if (selectedCustomer == null)
                {
                    return;
                }
                ID.Text = selectedCustomer.ID.ToString();
                Name.Text = selectedCustomer.Name;
                Address.Text = selectedCustomer.Address;
                PhoneNumber.Text = selectedCustomer.PhoneNumber;
                Email.Text = selectedCustomer.Email;
            }
        }
    }
}
