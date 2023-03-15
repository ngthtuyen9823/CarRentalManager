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

namespace CarRentalManager.ViewModel
{
    public class ListCarViewModel : BaseViewModel
    {
        private ObservableCollection<Car> list;
        public ObservableCollection<Car> List {get; set;}
        public ICommand AddCommand { get; set; }
        readonly CarDAO cardDao = new CarDAO();


        //CALL CONN IN Class DAO

        public ListCarViewModel()
        {
            List = getListObservableCar();
            AddCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                try
                {
                    //MessageBox.Show(string.Format("Da vao: {0}", Name));
                    //MessageBox.Show(string.Format("Da vao: {0}", ID));
                    //MessageBox.Show(string.Format("Da vao: {0}", Branch));
                    /*conn.Open();
                    string SQL = string.Format("INSERT INTO Car(id, name, branch) VALUES ('{0}', '{1}', '{2}')", ID, Name, Branch);
                    SqlCommand cmd = new SqlCommand(SQL, conn);
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("them thanh cong");
                    }*/
                }
                catch (Exception ex)
                {
                    MessageBox.Show("them that bai" + ex);
                }
                finally
                {
                    /*conn.Close();*/
                }

            });
        }
        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                if (value != name)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
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
        private string branch;

        public string Branch
        {
            get { return branch; }
            set
            {
                if (value != branch)
                {
                    branch = value;
                    OnPropertyChanged("Branch");
                }
            }
        }
        public ObservableCollection<Car> getListObservableCar()
        {
            List<Car> cars = cardDao.getListCar();
            ObservableCollection<Car> carList = new ObservableCollection<Car>(cars);
            return carList;
        }
    }
}