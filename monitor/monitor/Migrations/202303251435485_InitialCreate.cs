namespace monitor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GraphPoints",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        X = c.DateTime(nullable: false),
                        Y = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GraphPoints");
        }
    }
}
