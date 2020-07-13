namespace ProyectoFinal.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ProyectoFinal.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ProyectoFinal.Data.ProyectoFinalContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ProyectoFinal.Data.ProyectoFinalContext context)
        {
            context.Customers.AddOrUpdate(x => x.CustomerID,
        new Customer() { CustomerID = 1, Name = "Jane", LastName = "Austen", Birthdate = DateTime.Today, CreateAt= DateTime.Today, State = true },
        new Customer() { CustomerID = 2, Name = "Charles", LastName = "Dickens", Birthdate = DateTime.Today, CreateAt = DateTime.Today, State = true },
        new Customer() { CustomerID = 3, Name = "Miguel", LastName = "Cervantes", Birthdate = DateTime.Today, CreateAt = DateTime.Today, State = true }
        );

        }
    }
}
