﻿using CarRentalManager.models;
using MaterialDesignThemes.Wpf;
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
using static System.Net.Mime.MediaTypeNames;

namespace CarRentalManager
{
    /// <summary>
    /// Interaction logic for ContractView.xaml
    /// </summary>
    public partial class ContractView : UserControl
    {
        public ContractView()
        {
            InitializeComponent();
            FilterBy.ItemsSource = new string[] {"Status" };
        }
        private bool StatusFilter(object obj)
        {
            var Filterobj = obj as Contract;
            string filterobj1 = Filterobj.Status.ToString().ToLower();
            return filterobj1.Contains(FilterTextBox.Text.ToLower());
        }
     
        public Predicate<object> GetFilter()
        {
            switch (FilterBy.SelectedItem as string)
            {
                case "Status":
                    return StatusFilter;
            }
            return StatusFilter;
        }
        private void FilterBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FilterTextBox.Text == null)
            {
                lsvContract.Items.Filter = null;
            }
            else
            {
                lsvContract.Items.Filter = GetFilter();
            }
        }

        private void FilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            lsvContract.Items.Filter = GetFilter();
        }
        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            var item = sender as ListViewItem;
            if (item != null && item.IsSelected)
            {
                var selectedContract = lsvContract.SelectedItems[0] as Contract;
                if (selectedContract == null)
                {
                    return;
                }
                ID.Text = selectedContract.ID.ToString();
                OrderId.Text = selectedContract.OrderId.ToString();
                UserId.Text = selectedContract.UserId.ToString();
                Price.Text = selectedContract.Price.ToString();
                Status.Text = selectedContract.Status.ToString();
            }
        }
    }
}
