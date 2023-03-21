using CarRentalManager.enums;
using CarRentalManager.modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Controls;
using System.Data.Entity.Core.Metadata.Edm;

namespace CarRentalManager.services
{
    public class CustomerDataService
    {
        private readonly VariableService variableService = new VariableService();
        public CustomerDataService() { }

        public Customer craeteCustomerByRowData(DataRow row) {
            int id = variableService.parseStringToInt(row["id"].ToString());
            int.TryParse(row["id"].ToString(), out id);

            return new Customer(id,
                row["name"].ToString(),
                row["phoneNumber"].ToString(),
                row["email"].ToString(),
                row["idCard"].ToString(),
                row["address"].ToString(),
                row["imageIdCardFront"].ToString(),
                row["imageIdCardBack"].ToString());
        }
    }
}
