namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Customers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.Customers",
                    c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        IsSubscribeToNewsletter = c.Boolean(nullable: false),
                        MembershipTypeId = c.Int(nullable: false),
                        BirthDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.CustomerId)
                .ForeignKey("dbo.MembershipTypes", t => t.MembershipTypeId, cascadeDelete: true)
                .Index(t => t.MembershipTypeId);

            CreateTable(
                    "dbo.MembershipTypes",
                    c => new
                    {
                        MembershipTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        SignUpFee = c.Short(nullable: false),
                        DurationInMonths = c.Byte(nullable: false),
                        DiscountRate = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.MembershipTypeId);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershipTypeId" });
            DropTable("dbo.MembershipTypes");
            DropTable("dbo.Customers");
        }
    }
}
