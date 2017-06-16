namespace Identity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class some_name : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "FavoriteBook", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "FavoriteBook");
            DropTable("dbo.Movies");
        }
    }
}
