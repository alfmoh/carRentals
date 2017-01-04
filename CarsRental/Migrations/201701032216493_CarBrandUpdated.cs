namespace CarsRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CarBrandUpdated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CarBrands",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Cars", "ReleaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Cars", "DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Cars", "NumberInStock", c => c.Int(nullable: false));
            AddColumn("dbo.Cars", "CarBrandId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Cars", "CarBrandId");
            AddForeignKey("dbo.Cars", "CarBrandId", "dbo.CarBrands", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "CarBrandId", "dbo.CarBrands");
            DropIndex("dbo.Cars", new[] { "CarBrandId" });
            DropColumn("dbo.Cars", "CarBrandId");
            DropColumn("dbo.Cars", "NumberInStock");
            DropColumn("dbo.Cars", "DateAdded");
            DropColumn("dbo.Cars", "ReleaseDate");
            DropTable("dbo.CarBrands");
        }
    }
}
