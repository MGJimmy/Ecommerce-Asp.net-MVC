namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class innnn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "IsDeleted", c => c.Boolean(nullable: false, defaultValue : false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "IsDeleted");
        }
    }
}
