namespace CodeFirst1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEntityPost : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Post",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NamePost = c.String(),
                        Student_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Student", t => t.Student_ID)
                .Index(t => t.Student_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Post", "Student_ID", "dbo.Student");
            DropIndex("dbo.Post", new[] { "Student_ID" });
            DropTable("dbo.Post");
        }
    }
}
