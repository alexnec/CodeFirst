namespace CodeFirst1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCountry : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Student", "Country", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Student", "Country");
        }
    }
}
