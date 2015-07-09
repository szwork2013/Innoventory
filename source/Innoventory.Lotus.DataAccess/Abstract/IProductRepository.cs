﻿using Innoventory.Lotus.Database.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Innoventory.Lotus.Business.Abstract;
using Innoventory.Lotus.ViewModels;

namespace Innoventory.Lotus.Business.Abstract
{
    public interface IProductRepository : IGenericRepository<ProductViewModel>
    {
       
    }
}
