﻿using CarRentalManager.enums;
using CarRentalManager.modals;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManager.services
{
    public class UserDataService
    {
        private readonly VariableService variableService = new VariableService();
        public UserDataService() { }
        public User createUserByRowData(DataRow row)
        {
            EUserRole role = variableService.parseStringToEnum<EUserRole>(row["role"].ToString());
            int id = variableService.parseStringToInt(row["id"].ToString());
            DateTime createdAt = DateTime.Parse(row["createdAt"].ToString());
            DateTime updatedAt = DateTime.Parse(row["updatedAt"].ToString());

            //*TODO: UPDATE HASH PASSWORD LATER
            return new User(id,
                row["name"].ToString(),
                row["email"].ToString(),
                row["phoneNumber"].ToString(),
                row["password"].ToString(),
                role,
                createdAt, updatedAt);
        }

    }
}
