namespace Scada.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TagKeyUpdate : DbMigration
    {
        public override void Up()
        {

            DropTable("dbo.Tags");
            DropTable("dbo.Users");

            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        Description = c.String(nullable: false),
                        IoAddress = c.String(nullable: false),
                        Driver = c.String(),
                        ScanTime = c.Int(),
                        OnOffScan = c.Boolean(),
                        LowLimit = c.Double(),
                        HighLimit = c.Double(),
                        Units = c.String(),
                        Alarms = c.Boolean(),
                        InitialValue = c.Double(),
                        LowLimit1 = c.Double(),
                        HighLimit1 = c.Double(),
                        Units1 = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Name);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 128),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Username);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Tags");
        }
    }
}
