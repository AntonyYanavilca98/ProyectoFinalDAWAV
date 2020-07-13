using ProyectoFinal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProyectoFinal.Data
{
    public class ProyectoFinalContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    


        public ProyectoFinalContext() : base("name=MyContextDB")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

       

        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SalesInvoce> SalesInvoces { get; set; }
        public DbSet<SalesInvoceDetail> SalesInvoceDetails { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
