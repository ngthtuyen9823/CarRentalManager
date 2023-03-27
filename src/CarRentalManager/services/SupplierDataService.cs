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
    public class SupplierDataService
    {
        private readonly VariableService variableService = new VariableService();
        public SupplierDataService() { }

        public Supplier createSupplierByRowData(DataRow row)
        {
            int id = variableService.parseStringToInt(row["id"].ToString());
            int.TryParse(row["id"].ToString(), out id);

            return new Supplier(id,
                row["name"].ToString(),
                row["phoneNumber"].ToString(),
                row["email"].ToString(),
                row["address"].ToString()
                );
        }
    }
}
