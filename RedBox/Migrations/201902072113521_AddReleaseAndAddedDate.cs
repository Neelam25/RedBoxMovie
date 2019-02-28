namespace RedBox.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReleaseAndAddedDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MovieModels", "ReleasedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.MovieModels", "DateAdded", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MovieModels", "DateAdded");
            DropColumn("dbo.MovieModels", "ReleasedDate");
        }
    }
}
