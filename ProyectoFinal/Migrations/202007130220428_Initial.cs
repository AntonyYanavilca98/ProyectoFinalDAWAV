namespace ProyectoFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Birthdate = c.DateTime(nullable: false),
                        CreateAt = c.DateTime(nullable: false),
                        State = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Customers");
        }
    }
}
