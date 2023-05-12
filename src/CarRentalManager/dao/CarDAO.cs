using CarRentalManager.enums;
using CarRentalManager.services;
using System.Collections.Generic;
using System.Data;
using CarRentalManager.models;
using System.Linq;
using System.Windows;
using System;

namespace CarRentalManager.dao
{
    public class CarDAO
    {
        readonly SqlQueryService sqlService = new SqlQueryService();
        readonly CommondDataService commondDataService = new CommondDataService();
        readonly DbConnectionDAO dbConnectionDAO = new DbConnectionDAO();
        public CarDAO() { }

        public List<Car> getListCar()
        {
            string sqlStringGetTable = sqlService.getListTableData(ETableName.CAR);
            DataTable dataTable = dbConnectionDAO.getDataTable(sqlStringGetTable);   
            return commondDataService.dataTableToList<Car>(dataTable);
        }

        public void createCar(Car newCar)
        {
            string sqlString = sqlService.createNewCar(newCar);
            dbConnectionDAO.executing(sqlString, ETableName.CAR);
        }

        public void updateCar(Car updatedCar)
        {
            string sqlString = sqlService.updateCar(updatedCar);
            dbConnectionDAO.executing(sqlString, ETableName.CAR);
        }

        public void removeCar(int id)
        {
            string sqlString = sqlService.removeById(ETableName.CAR, id);
            dbConnectionDAO.executing(sqlString, ETableName.CAR);
        }

        public List<Car> getListCarByDescOrAsc(bool isDescrease, string fieldName)
        {
            string sqlStringGetTable = sqlService.getSortByDescOrAsc(isDescrease, fieldName, ETableName.CAR);
            DataTable dataTable = dbConnectionDAO.getDataTable(sqlStringGetTable);
            return commondDataService.dataTableToList<Car>(dataTable);
        }

        public Car getCarById(string id)
        {
            string sqlStringGetTable = sqlService.getValueById(id, ETableName.CAR);
            DataTable dataTable = dbConnectionDAO.getDataTable(sqlStringGetTable);
            return commondDataService.dataTableToList<Car>(dataTable)?.First();
        }

        public List<Car> getListCarByType(ECarType eCarType)
        {
            string sqlStringGetTable = sqlService.getListCarByType(eCarType);
            DataTable dataTable = dbConnectionDAO.getDataTable(sqlStringGetTable);
            return commondDataService.dataTableToList<Car>(dataTable);
        }
        public List<Car> getListByRange(int fromPrice, int toPrice)
        {
            string sqlStringGetTable = sqlService.getListByRange(fromPrice, toPrice);
            DataTable dataTable = dbConnectionDAO.getDataTable(sqlStringGetTable);
            return commondDataService.dataTableToList<Car>(dataTable);
        }

        public List<string> getListCarBrand(string fieldName)
        {
            string sqlStringGetTable = sqlService.getDistinctValueFromTable(fieldName, ETableName.CAR);
            DataTable dataTable = dbConnectionDAO.getDataTable(sqlStringGetTable);
            return dataTable.AsEnumerable()
                .Select(row => row[fieldName].ToString())
                .ToList();
        }
        public List<Car> getListCarByCondition(string City, string Brand, int Seats, DateTime Start, DateTime End)
        {
            try
            {
                string sqlStringGetTable = sqlService.getListCarByCondition(City, Brand, Seats, Start, End);
                DataTable dataTable = dbConnectionDAO.getDataTable(sqlStringGetTable);
                if (dataTable?.Rows?.Count != 0)
                    return commondDataService.dataTableToList<Car>(dataTable);
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
    }
}
