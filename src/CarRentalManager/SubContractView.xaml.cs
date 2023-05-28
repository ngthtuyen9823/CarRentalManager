using CarRentalManager.models;
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
    public partial class SubContractView : UserControl
    {
        public SubContractView()
        {
            InitializeComponent();
            FilterBy.ItemsSource = new string[] { "ID", "OrderId", "CustomerIdCard"};
        }
        private bool IDFilter(object obj)
        {
            var Filterobj = obj as ExtraContract;
            string filterobj = Filterobj.ID.ToString().ToLower();
            return filterobj.Contains(FilterTextBox.Text.ToLower());
        }
        private bool OrderIdFilter(object obj)
        {
            var Filterobj = obj as ExtraContract;
            string filterobj = Filterobj.OrderId.ToString().ToLower();
            return filterobj.Contains(FilterTextBox.Text.ToLower());
        }
        private bool CustomerIdCardFilter(object obj)
        {
            var Filterobj = obj as ExtraContract;
            string filterobj = Filterobj.CustomerIdCard.ToString().ToLower();
            return filterobj.Contains(FilterTextBox.Text.ToLower());
        }


        public Predicate<object> GetFilter()
        {
            switch (FilterBy.SelectedItem as string)
            {
                case "ID":
                    return IDFilter;
                case nameof(OrderId):
                    return OrderIdFilter;
            }
            return CustomerIdCardFilter;
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
                var selectedContract = lsvContract.SelectedItems[0] as ExtraContract;
                if (selectedContract == null)
                {
                    return;
                }
                OrderId.Text = selectedContract.OrderId.ToString();
                Price.Text = selectedContract.Price.ToString();
                ReceivedFee.Text = selectedContract.ReceivedFee.ToString(); 
                Status.Text = selectedContract.Status.ToString().Trim(); 
                CustomerName.Text = selectedContract.CustomerName.ToString();
                CustomerIdCard.Text = selectedContract.CustomerIdCard.ToString();
                CustomerPhone.Text = selectedContract.CustomerPhone.ToString();
            }
        }
    }
}
