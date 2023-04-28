using CarRentalManager.enums;
using CarRentalManager.models;
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
            FilterBy.ItemsSource = new string[] {"ID", "CarId", "CustomerId", "BookingPlace" };
        }
        private bool OrderIDFilter(object obj)
        {
            var Filterobj = obj as Order;
            string filterobj = Filterobj.ID.ToString().ToLower();
            return filterobj.Contains(FilterTextBox.Text.ToLower());
        }
        private bool CarIdFilter(object obj)
        {
            var Filterobj = obj as Order;
            string filterobj = Filterobj.CarId.ToString().ToLower();
            return filterobj.Contains(FilterTextBox.Text.ToLower());
        }
        private bool CustomerIdFilter(object obj)
        {
            var Filterobj = obj as Order;
            string filterobj = Filterobj.CustomerId.ToString().ToLower();
            return filterobj.Contains(FilterTextBox.Text.ToLower());
        }
        private bool BookingPlaceFilter(object obj)
        {
            var Filterobj = obj as Order;
            string filterobj = Filterobj.BookingPlace.ToLower();
            return filterobj.Contains(FilterTextBox.Text.ToLower());
        }
        public Predicate<object> GetFilter()
        {
            switch (FilterBy.SelectedItem as string)
            {
                case nameof(ID):
                    return OrderIDFilter;
                case nameof(CustomerId):
                    return CustomerIdFilter;
                case nameof(CarId):
                    return CarIdFilter;
                case nameof(BookingPlace):
                    return BookingPlaceFilter;
            }
            return BookingPlaceFilter;
        }
        private void FilterBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FilterTextBox.Text == null)
            {
                lsvOrder.Items.Filter = null;
            }
            else
            {
                lsvOrder.Items.Filter = GetFilter();
            }
        }

        private void FilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            lsvOrder.Items.Filter = GetFilter();
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