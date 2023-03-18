using CarRentalManager.modals;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using CarRentalManager.dao;
using System.Windows.Input;
using System.Windows;
using System.ComponentModel;
using System.Windows.Data;

namespace CarRentalManager.ViewModel
{
    public class ListOrderViewModel : BaseViewModel
    {
        private ObservableCollection<Order> list;
        public ObservableCollection<Order> List { get; set; }
        public ICommand AddCommand { get; set; }
        readonly OrderDAO orderDao = new OrderDAO();


        public ListOrderViewModel()
        {
            List = getListObservableOrder();
            AddCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                orderDao.addOrderToList(ID, CarId, CustomerId, BookingPlace, StartDate, EndDate, TotalFee);
                List = getListObservableOrder();
                OnPropertyChanged(nameof(List));
                //MessageBox.Show(String.Format("Da vao: {0}", ID));
                //MessageBox.Show(String.Format("Da vao: {0}", CustomerId));
                //MessageBox.Show(String.Format("Da vao: {0}", CarId));
                //MessageBox.Show(String.Format("Da vao: {0}", Status));
                //MessageBox.Show(String.Format("Da vao: {0}", BookingPlace));

                //MessageBox.Show(String.Format("Da vao: {0}", StartDate.ToString()));
                //MessageBox.Show(String.Format("Da vao: {0}", EndDate.ToString()));





            });
        }
 
        private int id;

        public int ID
        {
            get { return id; }
            set
            {
                if (value != id)
                {
                    id = value;
                    OnPropertyChanged("ID");
                }
            }
        }
        private int carId;

        public int CarId
        {
            get { return carId; }
            set
            {
                if (value != carId)
                {
                    carId = value;
                    OnPropertyChanged("CarId");
                }
            }
        }
        private int customerId;

        public int CustomerId
        {
            get { return customerId; }
            set
            {
                if (value != customerId)
                {
                    customerId = value;
                    OnPropertyChanged("CustomerId");
                }
            }
        }
        private int totalFee;

        public int TotalFee
        {
            get { return totalFee; }
            set
            {
                if (value != totalFee)
                {
                    totalFee = value;
                    OnPropertyChanged("TotalFee");
                }
            }
        }

        private string status;

        public string Status
        {
            get { return status; }
            set
            {
                if (value != status)
                {
                    status = value;
                    OnPropertyChanged("Status");
                }
            }
        }
        private string bookingPlace;
        public string BookingPlace
        {
            get { return bookingPlace; }
            set
            {
                if (value != bookingPlace)
                {
                    bookingPlace = value;
                    OnPropertyChanged("BookingPlace");
                }
            }
        }
        private DateTime startDate;

        public DateTime StartDate
        {
            get { return startDate; }
            set
            {
                if (value != startDate)
                {
                    startDate = value;
                    OnPropertyChanged("StartDate");
                }
            }
        }
        private DateTime endDate;

        public DateTime EndDate
        {
            get { return endDate; }
            set
            {
                if (value != endDate)
                {
                    endDate = value;
                    OnPropertyChanged("EndDate");
                }
            }
        }


        public ObservableCollection<Order> getListObservableOrder()
        {
            List<Order> Orders = orderDao.getListOrder();
            ObservableCollection<Order> OrderList = new ObservableCollection<Order>(Orders);
            return OrderList;
        }
    }
}


// cmd.CommandText="INSERT INTO person (birthdate) VALUES('"+dateTimePicker.Value.Date.ToString("yyyyMMdd")+"')";


//SqlCommand com = new SqlCommand("insert into Test values(@DtValue, con);
//com.Parameters.AddWithValue("DtValue", dateTimePicker1.Value.Date);