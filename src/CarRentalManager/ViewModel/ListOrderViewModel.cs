using CarRentalManager.modals;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CarRentalManager.dao;

namespace CarRentalManager.ViewModel
{
    public class ListOrderViewModel : BaseViewModel
    {
        private ObservableCollection<Order> list;
        public ObservableCollection<Order> List { get; set; }
        readonly OrderDAO orderDAO = new OrderDAO();

        public ListOrderViewModel()
        {
            List = getListObservableOrder();
        }
        public ObservableCollection<Order> getListObservableOrder()
        {
            List<Order> orders = orderDAO.getListOrder();
            ObservableCollection<Order> orderList = new ObservableCollection<Order>(orders);
            return orderList;
        }
    }
}
