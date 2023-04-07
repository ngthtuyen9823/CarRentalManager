﻿using CarRentalManager.enums;
using CarRentalManager.modals;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
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
    /// Interaction logic for OrderView.xaml
    /// </summary>
    public partial class OrderView : UserControl
    {
        public OrderView()
        {
            InitializeComponent();
        }
        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            var item = sender as ListViewItem;
            if (item != null && item.IsSelected)
            {
                var selectedOrder = lsvOrder.SelectedItems[0] as Order;
                if (selectedOrder == null)
                {
                    return;
                }
                ID.Text = selectedOrder.ID.ToString();
                CarId.Text = selectedOrder.CarId.ToString();
                CustomerId.Text = selectedOrder.CustomerId.ToString();
                BookingPlace.Text = selectedOrder.BookingPlace.ToString();
                TotalFee.Text = selectedOrder.TotalFee.ToString();
                CarId.Text = selectedOrder.CarId.ToString();
                Status.Text = selectedOrder.Status.ToString();
                StartDate.SelectedDate = selectedOrder.StartDate;
                EndDate.SelectedDate = selectedOrder.StartDate;

            }
        }
    }
}