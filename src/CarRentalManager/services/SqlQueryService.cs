using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
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
            return string.Format("SELECT * FROM {0} WHERE id='{1}'", tableName, id);
        }

        public string getSortByDescOrAsc(bool isDecrease, string fielddName, ETableName tableName)
        {
            string stringIsDesc = isDecrease ? "DESC" : "ASC";
            return string.Format("SELECT * FROM {0} ORDER BY {1} {2}", tableName, fielddName, stringIsDesc);
        }

        public string getLastId(ETableName tableName)
        {

            return string.Format("SELECT TOP 1 id FROM [dbo].[{0}] ORDER BY id DESC", tableName);
        }

        //*INFO: CAR


        //*INFO: USER
        public string getUserWithEmail(string email)
        {
            return string.Format("SELECT * FROM [{0}] WHERE email = '{1}'", ETableName.USER, email);
        }



        //*INFO: CUSTOMER



        //*INFO: CONTRACT



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

        public string createOrder(int ID, int CarId, int CustomerId, string BookingPlace, DateTime StartDate, DateTime EndDate, int TotalFee)
        {
            return string.Format("INSERT INTO {7}(id, carId, customerId, bookingPlace, startDate, endDate, totalFee) " +
                    "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')",
                    ID, CarId, CustomerId, BookingPlace, StartDate, EndDate, TotalFee,ETableName.ORDER);
        }
        //*INFO: RECEIPT


        
    }
}
