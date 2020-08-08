﻿using MattyStoreApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MattyStoreApp.DataAccess.Repository.IRepository
{
    public interface ICompanyRepository : IRepository<Company>
    {

        void Update(Company company);
    }
}
