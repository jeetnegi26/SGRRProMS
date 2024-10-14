namespace sgrrpms.AppDbContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RoleAssigns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        EditedOn = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        UserHostAdd = c.String(),
                        RewriteUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RoleDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleId = c.Int(nullable: false),
                        FormId = c.Int(nullable: false),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        EditedOn = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        UserHostAdd = c.String(),
                        RewriteUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        EditedOn = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        UserHostAdd = c.String(),
                        RewriteUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        HashPassword = c.String(),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        EditedOn = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        UserHostAdd = c.String(),
                        RewriteUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
            DropTable("dbo.RoleDetails");
            DropTable("dbo.RoleAssigns");
        }
    }
}
