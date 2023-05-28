using CarRentalManager.enums;
using CarRentalManager.services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Windows;
using System.Linq;
using System.Data.Entity.Migrations;
using System.Linq.Dynamic.Core;
using CarRentalManager.models;
using System.Windows.Documents;

namespace CarRentalManager.dao
{
    public class ContractDAO
    {
        readonly Context db = new Context();
        public ContractDAO() { }

        public Contract getContractById(string id)
        {
            return db.Contracts.Find(id);
        }

        public void createContract(Contract newContract)
        {
            db.Contracts.Add(newContract);
            db.SaveChanges();
        }

        public void removeContract(int id)
        {
            var contract = db.Contracts.Find(id.ToString());
            db.Contracts.Remove(contract);
            db.SaveChanges();
        }

        public void updateContract(Contract updatedContract)
        {
            db.Contracts.AddOrUpdate(updatedContract);
        }

        public List<Contract> getListContract()
        {
            return db.Contracts.ToList();
        }

        public List<ExtraContract> getListContractByOrderId(List<int> orderId)
        {
            var extraContracts =
                        from c in db.Contracts
                        join o in db.Orders on c.OrderId equals o.ID
                        join cus in db.Customers on o.CustomerId equals cus.ID
                        where (orderId.Any(o => o == c.OrderId))
                        select new { c, CustomerName = cus.Name, CustomerIdCard = cus.IdCard, CustomerPhone = cus.PhoneNumber };
            return (List<ExtraContract>)extraContracts;
        }

        public List<ExtraContract> getListExtraContract()
        {
            var extraContracts = (
                from c in db.Contracts
                join o in db.Orders on c.OrderId equals o.ID
                join cus in db.Customers on o.CustomerId equals cus.ID
                select new
                {
                    Contract = c,
                    CustomerName = cus.Name,
                    CustomerIdCard = cus.IdCard,
                    CustomerPhone = cus.PhoneNumber
                })
                .ToList();

            List<ExtraContract> result = new List<ExtraContract>();
            foreach (var item in extraContracts)
            {
                var extraContract = new ExtraContract
                {
                    ID = item.Contract.ID,
                    OrderId = item.Contract.OrderId,
                    UserId = item.Contract.UserId,
                    ReceivedFee = item.Contract.ReceivedFee,
                    Price = item.Contract.Price,
                    Paid = item.Contract.Paid,
                    Remain = item.Contract.Remain,
                    Status = item.Contract.Status,
                    Feedback = item.Contract.Feedback,
                    ReturnCarStatus = item.Contract.ReturnCarStatus,
                    Note = item.Contract.Note,
                    CustomerName = item.CustomerName,
                    CustomerIdCard = item.CustomerIdCard,
                    CustomerPhone = item.CustomerPhone
                };
                result.Add(extraContract);
            }
            return result;
        }

        public List<Contract> getListContractByMonth(int month, int year)
        {
            return db.Contracts.Where(p => p.UpdatedAt.Value.Month == month)
                    .Where(p => p.UpdatedAt.Value.Year == year).ToList();
        }

        public List<Contract> getListContractByYear(int year)
        {
            return db.Contracts.Where(p => p.UpdatedAt.Value.Year == year).ToList();
        }

        public List<Contract> getListContractByPreciouse(int preciouse, int year)
        {
            return db.Contracts.Where(p => p.UpdatedAt.Value.Month == (preciouse - 1) * 3 + 1 || p.UpdatedAt.Value.Month == (preciouse - 1) * 3 + 2 || p.UpdatedAt.Value.Month == (preciouse - 1) * 3 + 3)
                .Where(p => p.UpdatedAt.Value.Year == year).ToList();
        }
    }
}

