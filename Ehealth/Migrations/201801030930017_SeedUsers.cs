namespace Ehealth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'4000c4c1-23f4-4167-ab0d-ffcf58cb6aca', N'admin@ehealth.com', 0, N'AEJWaEN/PGZdz8j9yM1rrFaET0SSwT1JNCrnUcCZZ3rzrV6xNUfI81zDKPuZNJyU6g==', N'35faf6b1-7f79-4d03-9a2a-833452f6bd68', NULL, 0, 0, NULL, 1, 0, N'admin@ehealth.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'876f6ff3-bdca-4f4a-85aa-15e79274e68f', N'guest@ehealth.com', 0, N'ADw9pbsehxdCmzF0jA99CWYr/becpM6YcVY93CSYH55sAlyOnKWZTu2gHV1AIHgvTQ==', N'e57b42fc-18af-4b97-ae69-19ce6c7cf192', NULL, 0, 0, NULL, 1, 0, N'guest@ehealth.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'0f73f695-bed8-4916-a5da-bbe5ac77810d', N'CanManagePrograms')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'4000c4c1-23f4-4167-ab0d-ffcf58cb6aca', N'0f73f695-bed8-4916-a5da-bbe5ac77810d')

");
        }
        
        public override void Down()
        {
        }
    }
}
