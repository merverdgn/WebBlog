namespace WebBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostPicMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PostPics",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        URL = c.String(),
                        AUTHOR = c.String(),
                        UPDATE = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PostPics");
        }
    }
}
