namespace RedBox.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("Update MembershipTypes set Name='Pay as You Go' where ID=1");
            Sql("Update MembershipTypes set Name='Monthly' where ID=2");
            Sql("Update MembershipTypes set Name='Quarterly' where ID=3");
            Sql("Update MembershipTypes set Name='Yearly' where ID=4");
        }
        
        public override void Down()
        {
        }
    }
}
