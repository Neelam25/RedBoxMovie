namespace RedBox.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsSubscribedToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerModels", "IsSubscribedToMembership", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CustomerModels", "IsSubscribedToMembership");
        }
    }
}
