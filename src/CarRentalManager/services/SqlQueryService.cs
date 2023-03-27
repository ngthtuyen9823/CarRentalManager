using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Xml.Linq;
using CarRentalManager.enums;
using CarRentalManager.modals;

namespace CarRentalManager.services
{
    public class SqlQueryService
    {
        public SqlQueryService() { }

        //*INFO: COMMON
        public string getListTableData(ETableName tableName)
        {
            return string.Format("SELECT * FROM [{0}]", tableName);
        }

        public string getValueById(string id, ETableName tableName)
        {
            return string.Format("SELECT * FROM [{0}] WHERE id='{1}'", tableName, id);
        }

        public string getSortByDescOrAsc(bool isDecrease, string fielddName, ETableName tableName)
        {
            string stringIsDesc = isDecrease ? "DESC" : "ASC";
            return string.Format("SELECT * FROM [{0}] ORDER BY {1} {2}", tableName, fielddName, stringIsDesc);
        }

        public string getLastId(ETableName tableName)
        {

            return string.Format("SELECT TOP 1 id FROM [{0}] ORDER BY id DESC", tableName);
        }

        public string getDistinctValueFromTable(string fieldName, ETableName tableName)
        {
            return string.Format("SELECT DISTINCT {0} FROM [{1}]", fieldName, tableName);
        }

        //*INFO: CAR

        public string getListCarByType(ECarType eCarType)
        {
            return string.Format("SELECT * FROM [{0}] WHERE type = '{1}'", ETableName.CAR, eCarType);
        }
        public string createNewCar(int id, string name, string brand, string color, string publishYear, string type, string status, string drivingType, int seats, string licensePlate, int price, string imagePath, int? supplierId, DateTime createdAt, DateTime updatedAt)
        {
            return string.Format("INSERT INTO [{15}](id, name, brand, color, publishYear, type, status, drivingType, seats, licensePlate, price, imagePath, supplierId, createdAt, updatedAt) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}')",
                    id, name, brand, color, publishYear, type, status, drivingType, seats, licensePlate, price, imagePath, supplierId, DateTime.Now, DateTime.Now, ETableName.CAR);
        }
        public string getListByRange(int fromPrice, int toPrice)
        {
            return string.Format("SELECT * FROM [{0}] WHERE price > {1} and price <= {2}", ETableName.CAR, fromPrice, toPrice);
        }

        public string getListCarByCondition(string City, string Brand, string Seats)
        {
            string cityCondition =  City != null ? string.Format("city = '{0}'", City) : "city is not null";
            string brandCondition = " and " + (Brand != null ? string.Format("brand = '{0}'", Brand) : "brand is not null");
            string seatsCondition = " and " + (Seats != null ? string.Format("seats = '{0}'", Seats) : "seats is not null");
            return string.Format("SELECT * FROM [{0}] WHERE {1}", ETableName.CAR, cityCondition + brandCondition + seatsCondition);
        }


        public string removeCar(int id)
        {
            return string.Format("DELETE FROM [{0}] WHERE id = {1}", ETableName.CAR, id);
        }
        public string updateCar(int id, string name, string brand, string color, string publishYear, string type, string status, string drivingType, int seats, string licensePlate, int price, string imagePath, int? supplierId, DateTime createdAt, DateTime updatedAt)
        {
            return string.Format("UPDATE [{0}] SET name = '{1}', brand = '{2}', color = '{3}', publishYear = '{4}', type = '{5}', status = '{6}', drivingType = '{7}', seats = '{8}', licensePlate = '{9}', price = '{10}', imagePath = '{11}', supplierId = '{12}', createdAt = '{13}', updatedAt = '{14}' where id = '{15}'", 
            ETableName.CAR, name, brand, color, publishYear, type, status, drivingType, seats, licensePlate, price, imagePath, supplierId, DateTime.Now, DateTime.Now, id);
        }
        //*INFO: USER
        public string getUserWithEmail(string email)
        {
            return string.Format("SELECT * FROM [{0}] WHERE email = '{1}'", ETableName.USER, email);
        }

        //*INFO: CUSTOMER

        public string createNewCustomer(int id, string phoneNumber, string name, string email, 
            string idCard, string address, string imageIdCardFront, string imageIdCardBack)
        {
            return string.Format("INSERT INTO [{10}] VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}')",
                    id, phoneNumber, name, email, idCard, address, imageIdCardFront, imageIdCardBack, DateTime.Now, DateTime.Now, ETableName.CUSTOMER);
        }
        public string removeCustomer(int id)
        {
            return string.Format("DELETE FROM [{0}] WHERE id = {1}", ETableName.CUSTOMER, id);
        }

        //*INFO: SUPPLIER

        public string createNewSupplier(int id, string name, string phoneNumber, string email,
           string address)
        {
            return string.Format("INSERT INTO [{7}] VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')",
                    id, phoneNumber, name, email, address, DateTime.Now, DateTime.Now, ETableName.SUPPLIER);
        }

        //*INFO: CONTRACT

        public string createNewContract(int id, int orderId, int userId, string status, DateTime makingDay, DateTime createdAt, DateTime updatedAt)
        {
            return string.Format("INSERT INTO [{7}] VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')",
                   id, orderId, userId, DateTime.Now, status, DateTime.Now, DateTime.Now, ETableName.CONTRACT);
        }
       
        //*INFO: ORDER
        public string getListOrder()
        {
            return string.Format("SELECT * FROM [{0}] WHERE email = '{0}'", ETableName.ORDER);
        }

        public string updateOrder(string id, Order record)
        {
            //*TODO: UPDATE query later
            return string.Format("UPDATE * FROM [{0}] WHERE email = '{1}'", ETableName.ORDER, record);
        }

        public string deleteOrder(string id)
        {
            //*TODO: UPDATE query later
            return string.Format("DELETE FROM [{0}] WHERE id = '{1}'", ETableName.ORDER, id);
        }

        public string createOrder(int ID, int CarId, int CustomerId, string BookingPlace, DateTime StartDate, 
                DateTime EndDate, int TotalFee, int depositAmount, string imageEvidence, string notes)
        {
            return string.Format("INSERT INTO [{13}]" +
                    "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}')",
                    ID, CarId, CustomerId, BookingPlace, StartDate, EndDate, TotalFee, 
                        EOrderStatus.PENDING, depositAmount, imageEvidence, notes, DateTime.Now, DateTime.Now, ETableName.ORDER);
        }
        //*INFO: RECEIPT


        
    }
}
