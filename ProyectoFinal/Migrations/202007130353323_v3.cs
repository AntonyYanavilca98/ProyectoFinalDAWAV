namespace ProyectoFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SalesInvoceDetails", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.SalesInvoceDetails", "SellerID", "dbo.Sellers");
            DropIndex("dbo.SalesInvoceDetails", new[] { "CustomerID" });
            DropIndex("dbo.SalesInvoceDetails", new[] { "SellerID" });
            CreateIndex("dbo.SalesInvoceDetails", "SalesInvoceID");
            CreateIndex("dbo.SalesInvoceDetails", "ProductID");
            AddForeignKey("dbo.SalesInvoceDetails", "ProductID", "dbo.Products", "ProductID", cascadeDelete: true);
            AddForeignKey("dbo.SalesInvoceDetails", "SalesInvoceID", "dbo.SalesInvoces", "SalesInvoceID", cascadeDelete: true);
            DropColumn("dbo.SalesInvoceDetails", "CustomerID");
            DropColumn("dbo.SalesInvoceDetails", "SellerID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SalesInvoceDetails", "SellerID", c => c.Int(nullable: false));
            AddColumn("dbo.SalesInvoceDetails", "CustomerID", c => c.Int(nullable: false));
            DropForeignKey("dbo.SalesInvoceDetails", "SalesInvoceID", "dbo.SalesInvoces");
            DropForeignKey("dbo.SalesInvoceDetails", "ProductID", "dbo.Products");
            DropIndex("dbo.SalesInvoceDetails", new[] { "ProductID" });
            DropIndex("dbo.SalesInvoceDetails", new[] { "SalesInvoceID" });
            CreateIndex("dbo.SalesInvoceDetails", "SellerID");
            CreateIndex("dbo.SalesInvoceDetails", "CustomerID");
            AddForeignKey("dbo.SalesInvoceDetails", "SellerID", "dbo.Sellers", "SellerID", cascadeDelete: true);
            AddForeignKey("dbo.SalesInvoceDetails", "CustomerID", "dbo.Customers", "CustomerID", cascadeDelete: true);
        }
    }
}
