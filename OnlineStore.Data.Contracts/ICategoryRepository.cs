﻿using OnlineStore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Data.Contracts
{
    public interface ICategoryRepository : IRepository<Category,int>
    {
    }
}
