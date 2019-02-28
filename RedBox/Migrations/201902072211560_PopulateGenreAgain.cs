namespace RedBox.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenreAgain : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Genres Values('Action')");
            Sql("Insert into Genres Values('Drama')");
            Sql("Insert into Genres Values('Family')");
           
        }
        
        public override void Down()
        {
        }
    }
}
