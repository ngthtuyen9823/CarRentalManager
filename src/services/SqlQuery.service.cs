using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManager.services
{
    public class SqlQueryService
    {
        public SqlQueryService() { }

        public static string getUserWithEmail(string email)
        {
            return string.Format("SELECT * FROM {0} WHERE email = '{1}'", ETableName.HOCSINH, email);
        }

        public static string getListRecords()
        {
            return string.Format("SELECT * FROM {0} WHERE email = '{0}'", ETableName.RENTALINFORMATION);
        }

        public static string updateRecord(string id, )
        {
            //*TODO: UPDATE query later
            return string.Format("UPDATE * FROM {0} WHERE email = '{0}'", ETableName.RENTALINFORMATION);
        }

        public static string deleteRecord(string id)
        {
            //*TODO: UPDATE query later
            return string.Format("DELETE FROM {0} WHERE id = '{1}'", ETableName.RENTALINFORMATION, id);
        }
    }
}
