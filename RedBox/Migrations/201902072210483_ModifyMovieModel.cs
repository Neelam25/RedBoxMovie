namespace RedBox.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyMovieModel : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.MovieModels", new[] { "GenreID" });
            CreateIndex("dbo.MovieModels", "GenreId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.MovieModels", new[] { "GenreId" });
            CreateIndex("dbo.MovieModels", "GenreID");
        }
    }
}
