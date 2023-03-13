using System;
using System.Collections.Generic;
using System.Linq;
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
        public string getValueWithId(string id, ETableName tableName)
        {
            return string.Format("SELECT * FROM {0} WHERE id='{1}'", tableName, id);
        }



        //*INFO: CAR



        //*INFO: USER
        public string getUserWithEmail(string email)
        {
            return string.Format("SELECT * FROM [{0}] WHERE email = '{1}'", ETableName.USER, email);
        }



        //*INFO: CUSTOMER



        //*INFO: CONTRACT



        //*INFO: RECORD
        public string getListRecords()
        {
            return string.Format("SELECT * FROM [{0}] WHERE email = '{0}'", ETableName.RENTALINFORMATION);
        }

        public string updateRecord(string id, Order record)
        {
            //*TODO: UPDATE query later
            return string.Format("UPDATE * FROM [{0}] WHERE email = '{1}'", ETableName.RENTALINFORMATION, record);
        }

        public string deleteRecord(string id)
        {
            //*TODO: UPDATE query later
            return string.Format("DELETE FROM [{0}] WHERE id = '{1}'", ETableName.RENTALINFORMATION, id);
        }


        //*INFO: RECEIPT



        
    }
}
