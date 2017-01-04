namespace CarsRental.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateCarBrands : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO CarBrands (Id,Name) VALUES (1,'BMW')");
            Sql("INSERT INTO CarBrands (Id,Name) VALUES (2,'BENZ')");
            Sql("INSERT INTO CarBrands (Id,Name) VALUES (3,'LADA')");
            Sql("INSERT INTO CarBrands (Id,Name) VALUES (4,'TOYOTA')");
        }
        
        public override void Down()
        {
        }
    }
}
