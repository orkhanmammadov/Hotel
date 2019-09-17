namespace Hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bookingmodelchanged : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bookings", "MenuId", "dbo.Menus");
            DropIndex("dbo.Bookings", new[] { "MenuId" });
            RenameColumn(table: "dbo.Bookings", name: "MenuId", newName: "Menu_Id");
            AlterColumn("dbo.Bookings", "Menu_Id", c => c.Int());
            CreateIndex("dbo.Bookings", "Menu_Id");
            AddForeignKey("dbo.Bookings", "Menu_Id", "dbo.Menus", "Id");
            DropColumn("dbo.Bookings", "TotalPrice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bookings", "TotalPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropForeignKey("dbo.Bookings", "Menu_Id", "dbo.Menus");
            DropIndex("dbo.Bookings", new[] { "Menu_Id" });
            AlterColumn("dbo.Bookings", "Menu_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Bookings", name: "Menu_Id", newName: "MenuId");
            CreateIndex("dbo.Bookings", "MenuId");
            AddForeignKey("dbo.Bookings", "MenuId", "dbo.Menus", "Id", cascadeDelete: true);
        }
    }
}
