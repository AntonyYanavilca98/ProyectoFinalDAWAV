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
   

        }
    }
}
