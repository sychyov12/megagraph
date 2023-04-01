namespace monitor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GraphLists",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GraphPoints",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        GraphListId = c.Long(nullable: false),
                        X = c.DateTime(nullable: false),
                        Y = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GraphLists", t => t.GraphListId, cascadeDelete: true)
                .Index(t => t.GraphListId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GraphPoints", "GraphListId", "dbo.GraphLists");
            DropIndex("dbo.GraphPoints", new[] { "GraphListId" });
            DropTable("dbo.GraphPoints");
            DropTable("dbo.GraphLists");
        }
    }
}
