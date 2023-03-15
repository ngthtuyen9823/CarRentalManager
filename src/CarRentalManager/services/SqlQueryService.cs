using System;
using System.Collections.Generic;
using System.Linq;
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


        //*INFO: RECEIPT



        
    }
}
