namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedusers : DbMigration
    {
        public override void Up()
        {
            @Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'7477e164-2663-4115-84f6-8089d1569a1c', N'admin@vidly.com', 0, N'AOJsYg/xL/WwapFQkIkbfDIKEAeOWbPV3upDjFYBsGH5IHiHH6X5/U/ggHJIR5hRjg==', N'c43e51e9-817c-45a5-82d9-9269ffe431f4', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b96c2fc7-32c5-4371-acff-cbcbc180ddf5', N'user@vidly.com', 0, N'ACgvmuIPEe9HJkO2cegxoVQ2AJBbDuDvlVcam0HJpTBvxCy1EA7TnvNewkl5j0KaLg==', N'2e83f05e-e293-4744-9a1d-a3c632df54cb', NULL, 0, 0, NULL, 1, 0, N'user@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'40ce308f-e823-43d0-ae67-b68d930fb703', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'7477e164-2663-4115-84f6-8089d1569a1c', N'40ce308f-e823-43d0-ae67-b68d930fb703')
");
        }
        
        public override void Down()
        {
        }
    }
}
