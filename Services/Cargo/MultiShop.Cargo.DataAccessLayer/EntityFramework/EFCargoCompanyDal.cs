﻿using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Concrete;
using MultiShop.Cargo.DataAccessLayer.Repositories;
using MultiShop.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.DataAccessLayer.EntityFramework
{
    public class EFCargoCompanyDal:GenericRepository<CargoCompany>,ICargoCompanyDal
    {
        public EFCargoCompanyDal(CargoContext context):base(context)
        {
            
        }
    }
}
