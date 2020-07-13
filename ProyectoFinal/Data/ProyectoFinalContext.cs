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
        }

        public System.Data.Entity.DbSet<ProyectoFinal.Models.Customer> Customers { get; set; }

        public System.Data.Entity.DbSet<ProyectoFinal.Models.Seller> Sellers { get; set; }

        public System.Data.Entity.DbSet<ProyectoFinal.Models.SalesInvoceDetail> SalesInvoceDetails { get; set; }

        public System.Data.Entity.DbSet<ProyectoFinal.Models.SalesInvoce> SalesInvoces { get; set; }

        public System.Data.Entity.DbSet<ProyectoFinal.Models.Product> Products { get; set; }
    }
}
