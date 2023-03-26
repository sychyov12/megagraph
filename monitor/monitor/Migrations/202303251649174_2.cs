namespace monitor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.GraphPoints", new[] { "X" });
            CreateTable(
                "dbo.GraphLists",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.GraphPoints", "List_Id", c => c.Long());
            CreateIndex("dbo.GraphPoints", "List_Id");
            AddForeignKey("dbo.GraphPoints", "List_Id", "dbo.GraphLists", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GraphPoints", "List_Id", "dbo.GraphLists");
            DropIndex("dbo.GraphPoints", new[] { "List_Id" });
            DropColumn("dbo.GraphPoints", "List_Id");
            DropTable("dbo.GraphLists");
            CreateIndex("dbo.GraphPoints", "X", unique: true);
        }
    }
}
