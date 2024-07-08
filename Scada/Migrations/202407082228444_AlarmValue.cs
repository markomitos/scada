namespace Scada.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlarmValue : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AlarmValues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Type = c.Int(nullable: false),
                        Priority = c.Int(nullable: false),
                        Threshold = c.Double(nullable: false),
                        Unit = c.String(),
                        TagName = c.Int(nullable: false),
                        Value = c.Double(nullable: false),
                        Timestamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AlarmValues");
        }
    }
}
