namespace Scada.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TagValuesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TagValues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IOAddress = c.String(),
                        TagName = c.String(),
                        TimeStamp = c.DateTime(nullable: false),
                        Value = c.Double(nullable: false),
                        ValueType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.Tags");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
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
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.TagValues");
        }
    }
}
