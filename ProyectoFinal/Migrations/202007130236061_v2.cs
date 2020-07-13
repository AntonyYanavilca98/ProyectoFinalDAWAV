namespace ProyectoFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Stock = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Remarks = c.String(),
                        CreateAt = c.DateTime(nullable: false),
                        State = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID);
            
            CreateTable(
                "dbo.SalesInvoceDetails",
                c => new
                    {
                        SalesInvoceDetailID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Single(nullable: false),
                        SalesInvoceID = c.Int(nullable: false),
                        State = c.Boolean(nullable: false),
                        ProductID = c.Int(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        SellerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SalesInvoceDetailID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Sellers", t => t.SellerID, cascadeDelete: true)
                .Index(t => t.CustomerID)
                .Index(t => t.SellerID);
            
            CreateTable(
                "dbo.Sellers",
                c => new
                    {
                        SellerID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Birthdate = c.DateTime(nullable: false),
                        CreateAt = c.DateTime(nullable: false),
                        State = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SellerID);
            
            CreateTable(
                "dbo.SalesInvoces",
                c => new
                    {
                        SalesInvoceID = c.Int(nullable: false, identity: true),
                        Number = c.String(),
                        Payed = c.Boolean(nullable: false),
                        discount = c.Int(nullable: false),
                        Reason = c.String(),
                        CreateAt = c.DateTime(nullable: false),
                        State = c.Boolean(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        SellerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SalesInvoceID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Sellers", t => t.SellerID, cascadeDelete: true)
                .Index(t => t.CustomerID)
                .Index(t => t.SellerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SalesInvoces", "SellerID", "dbo.Sellers");
            DropForeignKey("dbo.SalesInvoces", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.SalesInvoceDetails", "SellerID", "dbo.Sellers");
            DropForeignKey("dbo.SalesInvoceDetails", "CustomerID", "dbo.Customers");
            DropIndex("dbo.SalesInvoces", new[] { "SellerID" });
            DropIndex("dbo.SalesInvoces", new[] { "CustomerID" });
            DropIndex("dbo.SalesInvoceDetails", new[] { "SellerID" });
            DropIndex("dbo.SalesInvoceDetails", new[] { "CustomerID" });
            DropTable("dbo.SalesInvoces");
            DropTable("dbo.Sellers");
            DropTable("dbo.SalesInvoceDetails");
            DropTable("dbo.Products");
        }
    }
}
