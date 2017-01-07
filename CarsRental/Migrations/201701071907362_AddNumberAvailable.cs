namespace CarsRental.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddNumberAvailable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "NumberAvailable", c => c.Byte(nullable: false));
            Sql("UPDATE Cars SET NumberAvailable = NumberInStock");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cars", "NumberAvailable");
        }
    }
}
