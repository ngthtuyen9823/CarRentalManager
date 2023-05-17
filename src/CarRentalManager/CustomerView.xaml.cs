using CarRentalManager.models;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
    /// Interaction logic for CustomerView.xaml
    /// </summary>
    public partial class CustomerView : UserControl
    {
        public CustomerView()
        {
            InitializeComponent();
            FilterBy.ItemsSource = new string[] { "ID", "Name", "Address", "Email", "PhoneNumber", "IdCard" };
        }
        private bool IDFilter(object obj)
        {
            var Filterobj = obj as Customer;
            string filterobj = Filterobj.ID.ToString().ToLower();
            return filterobj.Contains(FilterTextBox.Text.ToLower());
        }
            private bool NameFilter(object obj)
        {
            var Filterobj = obj as Customer;
            string filterobj = Filterobj.Name.ToLower();
            return filterobj.Contains(FilterTextBox.Text.ToLower());
        }
        private bool AddressFilter(object obj)
        {
            var Filterobj = obj as Customer;
            string filterobj = Filterobj.Address.ToLower();
            return filterobj.Contains(FilterTextBox.Text.ToLower());
        }
        private bool EmailFilter(object obj)
        {
            var Filterobj = obj as Customer;
            string filterobj = Filterobj.Email.ToLower();
            return filterobj.Contains(FilterTextBox.Text.ToLower());
        }
        private bool PhoneNumberFilter(object obj)
        {
            var Filterobj = obj as Customer;
            string filterobj = Filterobj.PhoneNumber.ToLower();
            return filterobj.Contains(FilterTextBox.Text.ToLower());
        }
        private bool IdCardFilter(object obj)
        {
            var Filterobj = obj as Customer;
            string filterobj = Filterobj.IDCard.ToString().ToLower();
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
                case nameof(IdCard):
                    return IdCardFilter;
            }
            return AddressFilter;
        }
        private void FilterBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FilterTextBox.Text == null)
            {
                lsvCustomer.Items.Filter = null;
            }
            else
            {
                lsvCustomer.Items.Filter = GetFilter();
            }
        }

        private void FilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            lsvCustomer.Items.Filter = GetFilter();
        }
        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            var item = sender as ListViewItem;
            if (item != null && item.IsSelected)
            {
                var selectedCustomer = lsvCustomer.SelectedItems[0] as Customer;
                if (selectedCustomer == null)
                {
                    return;
                }
                ID.Text = selectedCustomer.ID.ToString();
                Name.Text = selectedCustomer.Name;
                Address.Text = selectedCustomer.Address;
                PhoneNumber.Text = selectedCustomer.PhoneNumber;
                Email.Text = selectedCustomer.Email;
                IdCard.Text = selectedCustomer.IDCard;
            }
        }
    }
}
