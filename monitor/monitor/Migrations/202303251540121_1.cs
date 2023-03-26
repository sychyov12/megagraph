namespace monitor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.GraphPoints", "X", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.GraphPoints", new[] { "X" });
        }
    }
}
