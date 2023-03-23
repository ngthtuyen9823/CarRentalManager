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
    public class CarDataService
    {
        private readonly VariableService variableService = new VariableService();
        public CarDataService() { }

        public Car createCarByRowData(DataRow row) {
            ECarStatus status = variableService.parseStringToEnum<ECarStatus>(row["status"].ToString());
            ECarType type = variableService.parseStringToEnum<ECarType>(row["type"].ToString());
            EDrivingType drivingType = variableService.parseStringToEnum<EDrivingType>(row["drivingType"].ToString());
            int id = variableService.parseStringToInt(row["id"].ToString());
            int publishYear = variableService.parseStringToInt(row["publishYear"].ToString());
            int price = variableService.parseStringToInt(row["price"].ToString());
            int seats = variableService.parseStringToInt(row["seats"].ToString());
            int? supplierId = null;
            if (row["supplierId"].ToString() != null)
            {
                supplierId = variableService.parseStringToInt(row["supplierId"].ToString());
            }

            return new Car(id,
                row["name"].ToString(),
                row["brand"].ToString(),
                publishYear,
                row["color"].ToString(),
                price,
                status,
                type,
                drivingType,
                seats,
                row["licensePlate"].ToString(),
                row["imagePath"].ToString(),
                row["tutorialPath"].ToString(),
                row["city"].ToString(),
                supplierId);
        }
    }
}
