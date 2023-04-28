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
            FilterBy.ItemsSource = new string[] {"ID", "Name", "Address", "Email", "PhoneNumber" };
        }
        private bool IDFilter(object obj)
        {
            var Filterobj = obj as Supplier;
            string filterobj = Filterobj.ID.ToString().ToLower();
            return filterobj.Contains(FilterTextBox.Text.ToLower());
        }
        private bool NameFilter(object obj)
        {
            var Filterobj = obj as Supplier;
            string filterobj = Filterobj.Name.ToLower();
            return filterobj.Contains(FilterTextBox.Text.ToLower());
        }
        private bool AddressFilter(object obj)
        {
            var Filterobj = obj as Supplier;
            string filterobj = Filterobj.Address.ToLower();
            return filterobj.Contains(FilterTextBox.Text.ToLower());
        }
        private bool EmailFilter(object obj)
        {
            var Filterobj = obj as Supplier;
            string filterobj = Filterobj.Email.ToLower();
            return filterobj.Contains(FilterTextBox.Text.ToLower());
        }
        private bool PhoneNumberFilter(object obj)
        {
            var Filterobj = obj as Supplier;
            string filterobj = Filterobj.PhoneNumber.ToLower();
            return filterobj.Contains(FilterTextBox.Text.ToLower());
        }
        public Predicate<object> GetFilter()
        {
            switch (FilterBy.SelectedItem as string)
            {
                case nameof(ID):
                    return IDFilter;
                case nameof(Name):
                    return NameFilter;
                case nameof(Address):
                    return AddressFilter;
                case nameof(PhoneNumber):
                    return PhoneNumberFilter;
                case nameof(Email):
                    return EmailFilter;
            }
            return AddressFilter;
        }
        private void FilterBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FilterTextBox.Text == null)
            {
                lsvSupplier.Items.Filter = null;
            }
            else
            {
                lsvSupplier.Items.Filter = GetFilter();
            }
        }

        private void FilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            lsvSupplier.Items.Filter = GetFilter();
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
