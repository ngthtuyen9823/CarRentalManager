using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalManager.modals;
using CarRentalManager.services;

namespace CarRentalManager.dao
{
    public class RentalInformationDAO
    {
        public RentalInformationDAO() { }

        public static Order[] getListRecords()
        {
            /*string queryString = SqlQueryService.getListRecords();*/
            //*TODO: Update call database later
            return null;
        }

        public static void updateRecord(string id, Order updatedRecord)
        {
            /*string queryString = SqlQueryService.updateRecord(id, updatedRecord);*/
            //*TODO: Update call database later
        }

        public static void deleteRecord(string id)
        {
            /*string queryString = SqlQueryService.deleteRecord(id);*/
            //*TODO: Update call database later
        }
    }
}
