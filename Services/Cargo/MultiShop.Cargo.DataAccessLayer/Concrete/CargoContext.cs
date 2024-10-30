﻿using Microsoft.EntityFrameworkCore;
using MultiShop.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.DataAccessLayer.Concrete
{
    public class CargoContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1441;Initial Catalog=MultiShopCargoDb;User Id=sa;Password=214751471936Aa**;TrustServerCertificate=True");
        }
        public DbSet<CargoCompany> CargoCompanies { get; set; }
        public DbSet<CargoDetail> CargoDetails{ get; set; }
        public DbSet<CargoCustomer> CargoCustomers{ get; set; }
        public DbSet<CargoOperation> CargoOperations{ get; set; }

    }
}