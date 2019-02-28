namespace RedBox.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNumberInStock : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MovieModels", "NumberInStock", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MovieModels", "NumberInStock");
        }
    }
}
