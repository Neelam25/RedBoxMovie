namespace RedBox.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDOBtoCustomerModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerModels", "DOB", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CustomerModels", "DOB");
        }
    }
}
