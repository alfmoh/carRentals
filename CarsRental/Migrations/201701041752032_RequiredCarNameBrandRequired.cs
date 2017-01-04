namespace CarsRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequiredCarNameBrandRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cars", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cars", "Name", c => c.String());
        }
    }
}
