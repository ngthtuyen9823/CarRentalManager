﻿using CarRentalManager.models;
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
            FilterBy.ItemsSource = new string[] { "Address", "Email", "PhoneNumber", "IDCard"};
            //FilterBy.ItemsSource = typeof(Car).GetProperties().Select((o) => o.Name);
        }
        private bool AddressFilter(object obj)
        {
            var Filterobj = obj as Customer;
            string filterobj1 = Filterobj.Address.ToLower().ToString();
            return filterobj1.Contains(FilterTextBox.Text.ToLower());
        }
        private bool EmailFilter(object obj)
        {
            var Filterobj = obj as Customer;
            string filterobj1 = Filterobj.Email.ToLower().ToString();
            return filterobj1.Contains(FilterTextBox.Text.ToLower());
        }
        private bool PhoneNumberFilter(object obj)
        {
            var Filterobj = obj as Customer;
            string filterobj1 = Filterobj.PhoneNumber.ToLower().ToString();
            return filterobj1.Contains(FilterTextBox.Text.ToLower());
        }
        private bool IdCardFilter(object obj)
        {
            var Filterobj = obj as Customer;
            string filterobj1 = Filterobj.IDCard.ToString().ToLower().ToString();
            return filterobj1.Contains(FilterTextBox.Text.ToLower());
        }
        public Predicate<object> GetFilter()
        {
            switch (FilterBy.SelectedItem as string)
            {
                case "Address":
                    return AddressFilter;
                case "PhoneNumber":
                    return PhoneNumberFilter;
                case "Email":
                    return EmailFilter;
                case "IdCard":
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
                IdCard.Text = selectedCustomer.IDCard.ToString();
            }
        }
    }
}
