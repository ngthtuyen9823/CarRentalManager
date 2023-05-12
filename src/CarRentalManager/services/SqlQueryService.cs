using System;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using CarRentalManager.enums;
using CarRentalManager.models;

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

        public string removeById(ETableName tableName, int id)
        {
            return string.Format("DELETE FROM [{0}] WHERE id = {1}", tableName, id);
        }
        public string getListByCondition(ETableName tableName, string condition)
        {
            return string.Format("SELECT * FROM [{0}] where {1}", tableName, condition);
        }

        public string getListFeedbackOfCustomer()
        {
            return $"SELECT name, MIN(feedback) AS feedback" +
                $" FROM [{ETableName.CONTRACT}] " +
                $" JOIN [{ETableName.ORDER}] ON [{ETableName.CONTRACT}].orderId = [{ETableName.ORDER}].id" +
                $" JOIN [{ETableName.CUSTOMER}] ON [{ETableName.ORDER}].customerId = [{ETableName.CUSTOMER}].id" +
                $" WHERE returnCarStatus = '{EReturnCarStatus.INTACT}' " +
                $" AND feedback IS NOT NULL AND FEEDBACK <> ''" +
                $" GROUP BY name";
        }
        public string getCreadentialWithEmail(ETableName tableName, string email)
        {
            return string.Format("SELECT * FROM [{0}] WHERE email = '{1}'", tableName, email);
        }


        //*INFO: CAR

        public string getListCarByType(ECarType eCarType)
        {
            return string.Format("SELECT * FROM [{0}] WHERE type = '{1}'", ETableName.CAR, eCarType);
        }
        public string createNewCar(Car newCar)
        {
            return string.Format("INSERT INTO [{15}](id, name, brand, color, publishYear, type, status, drivingType, seats, licensePlate, price, imagePath, supplierId, createdAt, updatedAt) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}')",
                    newCar.ID, newCar.Name,
                    newCar.Brand, newCar.Color,
                    newCar.PublishYear, newCar.Type,
                    newCar.Status, newCar.DrivingType,
                    newCar.Seats, newCar.LicensePlate,
                    newCar.Price, newCar.ImagePath,
                    newCar.SupplierId, DateTime.Now,
                    DateTime.Now, ETableName.CAR);
        }
        public string getListByRange(int fromPrice, int toPrice)
        {
            return string.Format("SELECT * FROM [{0}] WHERE price > {1} and price <= {2}", ETableName.CAR, fromPrice, toPrice);
        }

        public string getListCarAvailable(DateTime Start, DateTime End)
        {
            string availbleCondition = $"SELECT carId FROM [{ETableName.ORDER}] WHERE startDate >= '{Start}' and endDate <= '{End}' and status <> '{EOrderStatus.CANCELBYADMIN}' and status <> '{EOrderStatus.CANCELBYUSER}'";
            return $"SELECT [{ETableName.CAR}].* FROM [{ETableName.CAR}] LEFT JOIN ({availbleCondition})A on [{ETableName.CAR}].id = A.carId WHERE A.carId is null";
        }

        public string getListCarByCondition(string City, string Brand, int Seats, DateTime Start, DateTime End)
        {
            string cityCondition = City != null ? string.Format("city = '{0}'", City) : "";
            string brandCondition = (Brand != null ? (City != null ? " and " : "") + string.Format("brand = '{0}'", Brand) : "");
            string seatsCondition = (Seats != 0 ? (Brand != null || City != null ? " and " : "") + string.Format("seats = '{0}'", Seats) : "");
            string carPropCondtion = cityCondition + brandCondition + seatsCondition != "" ? "and " + cityCondition + brandCondition + seatsCondition : "";
            return $"{getListCarAvailable(Start, End)} {carPropCondtion}";
        }

        public string updateCar(Car updatedCar)
        {
            return string.Format("UPDATE [{0}] SET name = '{1}', brand = '{2}', color = '{3}', publishYear = '{4}', type = '{5}', status = '{6}', drivingType = '{7}', seats = '{8}', licensePlate = '{9}', price = '{10}', imagePath = '{11}', supplierId = '{12}', updatedAt = '{13}' where id = '{14}'",
                ETableName.CAR, updatedCar.Name,
                updatedCar.Brand, updatedCar.Color,
                updatedCar.PublishYear, updatedCar.Type,
                updatedCar.Status, updatedCar.DrivingType,
                updatedCar.Seats, updatedCar.LicensePlate,
                updatedCar.Price, updatedCar.ImagePath,
                updatedCar.SupplierId, DateTime.Now, updatedCar.ID);
        }

        public string checkIsAvailable(DateTime start, DateTime end, int carId)
        {
            return $"SELECT COUNT(*)isExist FROM ({getListCarAvailable(start, end)})A WHERE id = '{carId}'";
        }


        //*INFO: CUSTOMER

        public string createCustomer(Customer newCustomer)
        {
            return string.Format("INSERT INTO [{0}] VALUES ('{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}')",
                    ETableName.CUSTOMER,
                    newCustomer.ID, newCustomer.PhoneNumber,
                    newCustomer.Name, newCustomer.Email,
                    newCustomer.IDCard, newCustomer.Address,
                    newCustomer.ImageIdCardFront, newCustomer.ImageIdCardBack,
                    DateTime.Now, DateTime.Now);
        }
        public string updateCustomer(Customer updatedCustomer)
        {
            return string.Format("UPDATE [{0}] SET name = '{1}', phoneNumber = '{2}', email = '{3}', idCard = '{4}', address = '{5}', imageIdCardFront = '{6}', imageIdCardBack = '{7}', updatedAt = '{8}' where id = '{9}'",
                ETableName.CUSTOMER,
                updatedCustomer.Name, updatedCustomer.PhoneNumber,
                updatedCustomer.Email, updatedCustomer.IDCard,
                updatedCustomer.Address, updatedCustomer.ImageIdCardFront,
                updatedCustomer.ImageIdCardBack,
                DateTime.Now, updatedCustomer.ID);
        }

        //*INFO: SUPPLIER

        public string createSupplier(Supplier newSupplier)
        {
            return string.Format("INSERT INTO [{0}] VALUES ('{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}')",
                    ETableName.SUPPLIER,
                    newSupplier.ID, newSupplier.Email, 
                    newSupplier.Password, newSupplier.PhoneNumber,
                    newSupplier.Name, newSupplier.Address, 
                    DateTime.Now, DateTime.Now);
        }

        public string updateSupplier(Supplier updatedSupplier)
        {
            return string.Format("UPDATE [{0}] SET name = '{1}', phoneNumber = '{2}', email = '{3}', idCard = '{4}', address = '{5}', imageIdCardFront = '{6}', imageIdCardBack = '{7}', updatedAt = '{8}' where id = '{9}'",
                ETableName.SUPPLIER,
                updatedSupplier.ID, updatedSupplier.PhoneNumber,
                updatedSupplier.Name, updatedSupplier.Email,
                updatedSupplier.Address, DateTime.Now,
                updatedSupplier.ID);
        }

        //*INFO: CONTRACT

        public string createNewContract(Contract newContract)
        {
            return string.Format("INSERT INTO [{0}] VALUES ('{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}')",
                   ETableName.CONTRACT, 
                   newContract.ID, 
                   newContract.OrderId, 
                   newContract.UserId, 
                   newContract.Status,
                   newContract.Price, 
                   newContract.Paid,
                   newContract.Remain,
                   newContract.Feedback,
                   newContract.ReturnCarStatus,
                   newContract.Note,
                   DateTime.Now,
                   DateTime.Now);
        }

        public string updateContract(Contract updatedContract)
        {
            return string.Format("UPDATE [{0}] SET userId = '{1}', orderId = '{2}', status = '{3}', price = '{4}', paid = '{5}', remain = '{6}', feedback = '{7}', returnCarStatus = '{8}', note = '{9}',  updatedAt = '{10}' where id = '{11}'",
            ETableName.CONTRACT,
            updatedContract.UserId,
            updatedContract.OrderId,
            updatedContract.Status,
            updatedContract.Price,
            updatedContract.Paid,
            updatedContract.Remain,
            updatedContract.Feedback,
            updatedContract.ReturnCarStatus,
            updatedContract.Note,
            DateTime.Now,
            updatedContract.ID);
        }

        //*INFO: ORDER
        public string getListOrder()
        {
            return string.Format("SELECT * FROM [{0}] WHERE email = '{0}'", ETableName.ORDER);
        }

        public string updateOrder(Order newOrder)
        {
            return string.Format("UPDATE [{0}] SET carId = '{1}', customerId = '{2}', bookingPlace = '{3}', startDate = '{4}', endDate = '{5}', totalFee = '{6}', status = '{7}', depositAmount = '{8}', imageEvidence = '{9}', notes = '{10}', updatedAt = '{11}' where id = '{12}' ",
                ETableName.ORDER,
                    newOrder.CarId,
                    newOrder.CustomerId, newOrder.BookingPlace,
                    newOrder.StartDate, newOrder.EndDate,
                    newOrder.TotalFee, newOrder.Status,
                    newOrder.DepositAmount, newOrder.ImageEvidence,
                    newOrder.Notes, DateTime.Now, newOrder.ID);
        }
        public string updateStatusOfOrder(Order newOrder)
        {
            return string.Format("UPDATE [{0}] SET status = '{1}', updatedAt = '{2}' where id = '{3}' ",
                ETableName.ORDER,
                    EOrderStatus.COMPLETE,
                    DateTime.Now,
                    newOrder.ID);
        }

        public string createOrder(Order newOrder)
        {
            return string.Format("INSERT INTO [{0}]" +
                    "VALUES ('{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}')",
                    ETableName.ORDER,
                    newOrder.ID, newOrder.CarId,
                    newOrder.CustomerId, newOrder.BookingPlace,
                    newOrder.StartDate, newOrder.EndDate,
                    newOrder.TotalFee, newOrder.Status,
                    newOrder.DepositAmount, newOrder.ImageEvidence,
                    newOrder.Notes, DateTime.Now, DateTime.Now);
        }


        //*INFO: RECEIPT
        public string updateReceipt(Receipt newReceipt)
        {
            //*TODO: UPDATE query later
            return string.Format("UPDATE [{0}] SET contractId = '{1}', price = '{2}', updatedAt = '{3}' where id = '{4}' ",
                ETableName.ORDER, newReceipt.ContractId, newReceipt.Price, DateTime.Now, newReceipt.ID);
        }

        public string createReceipt(Receipt newReceipt)
        {
            return string.Format("INSERT INTO [{0}]" +
                    "VALUES ('{1}', '{2}', '{3}', '{4}', '{5}', '{6}')",
                    ETableName.ORDER, newReceipt.ID, newReceipt.ContractId, newReceipt.Price, DateTime.Now, DateTime.Now);
        }


        //*INFO: STATISTIC
        public string countOnrentTimes()
        {
            return "SELECT name, COUNT([Contract].id) as onrentTimes " +
                    "FROM[Order] " +
                    "JOIN[Contract] on[Order].id = [Contract].orderId " +
                    "JOIN[Car] on[Order].carId = [Car].id " +
                    "GROUP BY name";
        }

        public string countBrokenTimes()
        {
            return "SELECT name, COUNT([Contract].id) as brokenTimes " +
                "FROM [Contract] " +
                "JOIN [Order] ON[Contract].orderId = [Order].id " +
                "JOIN [Car] on [Order].carId = [Car].id " +
                "WHERE [Contract].returnCarStatus = 'BROKEN' " +
                "GROUP BY name";
        }
    }
}
