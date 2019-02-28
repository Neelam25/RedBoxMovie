namespace RedBox.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenre : DbMigration
    {
        public override void Up()
        {
         
            Sql("Insert into Genres Values('Comedy')");
            Sql("Insert into Genres Values('Action')");
            Sql("Insert into Genres Values('Drama')");
            Sql("Insert into Genres Values('Family')");

        }
        
        public override void Down()
        {
        }
    }
}
