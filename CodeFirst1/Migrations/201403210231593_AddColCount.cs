namespace CodeFirst1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColCount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Course", "Count", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Course", "Count");
        }
    }
}
