namespace RedBox.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenreToMovie : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        ID = c.Short(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.MovieModels", "GenreID", c => c.Short(nullable: false));
            CreateIndex("dbo.MovieModels", "GenreID");
            AddForeignKey("dbo.MovieModels", "GenreID", "dbo.Genres", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovieModels", "GenreID", "dbo.Genres");
            DropIndex("dbo.MovieModels", new[] { "GenreID" });
            DropColumn("dbo.MovieModels", "GenreID");
            DropTable("dbo.Genres");
        }
    }
}
