using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
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

        //*INFO: CAR
        
        public string getListCarByType(ECarType eCarType)
        {
            return string.Format("SELECT * FROM [{0}] WHERE type = '{1}'", ETableName.CAR, eCarType);
        }
        public string createNewCar(int id, string name, string brand, string color, string publishYear, string type, string status, string drivingType, int seats, string licensePlate, int price, string imagePath, DateTime createdAt, DateTime updatedAt)
        {
            return string.Format("INSERT INTO [{14}](id, name, brand, color, publishYear, type, status, drivingType, seats, licensePlate, price, imagePath, createdAt, updatedAt) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}')",
                    id, name, brand, color, publishYear, type, status, drivingType, seats, licensePlate, price, imagePath, DateTime.Now, DateTime.Now, ETableName.CAR);
        }
        public string getListByRange(int fromPrice, int toPrice)
        {
            return string.Format("SELECT * FROM [{0}] WHERE price > {1} and price <= {2}", ETableName.CAR, fromPrice, toPrice);
        }
        


        //*INFO: USER
        public string getUserWithEmail(string email)
        {
            return string.Format("SELECT * FROM [{0}] WHERE email = '{1}'", ETableName.USER, email);
        }

        public string removeCustomer(int id)
        {
            return string.Format("DELETE FROM [{0}] WHERE id = {1}", ETableName.CUSTOMER, id);
        }


        //*INFO: CUSTOMER

        public string createNewCustomer(int id, string phoneNumber, string name, string email, 
            string idCard, string address, string imageIdCardFront, string imageIdCardBack)
        {
            return string.Format("INSERT INTO [{10}] VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}')",
                    id, phoneNumber, name, email, idCard, address, imageIdCardFront, imageIdCardBack, DateTime.Now, DateTime.Now, ETableName.CUSTOMER);
        }

        //*INFO: CONTRACT

        public string createNewContract(int id, int orderId, int userId, DateTime makingDay, DateTime createdAt, DateTime updatedAt)
        {
            return string.Format("INSERT INTO [{6}] VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')",
                   id, orderId, userId, DateTime.Now, DateTime.Now, DateTime.Now, ETableName.CONTRACT);
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
