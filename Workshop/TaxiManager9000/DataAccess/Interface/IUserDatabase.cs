﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiManager9000.Domain.Entities;

namespace TaxiManager9000.DataAccess.Interface
{
    public interface IUserDatabase : IDatabase<User>
    {
        User GetByUserNameAndPassword(string username, string password);
        User GetByUserName(string userName);
    }

}
