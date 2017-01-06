namespace CarsRental.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'9f8b3179-31f0-491c-815b-a2d5d1b8469e', N'guest@car.com', 0, N'AL1PxUqFmjhBdz0x0dP+LTCkIOJVL3cGQeI0UAzHbklDnz29GRYpV58qs0b3x0aFYg==', N'4c2cab89-70ee-4d52-a1f2-1e08c18c8aae', NULL, 0, 0, NULL, 1, 0, N'guest@car.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'c02d5ea6-ee12-444d-bfa2-5a712ec4fe43', N'admin@car.com', 0, N'AK0PnwYNMAhxSrjV6mZgBfOTFh0ewiqfl5fBrczFXGie+Rz7uL8F5TAtPIs96N3rpg==', N'001736c7-d0f9-4660-957e-6e55fb40b86f', NULL, 0, 0, NULL, 1, 0, N'admin@car.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'e122eb2a-9d91-4bda-b95f-7697b54b8acc', N'CanManageCars')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'c02d5ea6-ee12-444d-bfa2-5a712ec4fe43', N'e122eb2a-9d91-4bda-b95f-7697b54b8acc')

");
        }
        
        public override void Down()
        {
        }
    }
}
