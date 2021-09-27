namespace MovieCinemas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdministratorPermissions",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        AdministratorId = c.Guid(nullable: false),
                        PermissionId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Administrators", t => t.AdministratorId, cascadeDelete: true)
                .ForeignKey("dbo.Permissions", t => t.PermissionId, cascadeDelete: true)
                .Index(t => t.AdministratorId)
                .Index(t => t.PermissionId);
            
            CreateTable(
                "dbo.Administrators",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Password = c.String(),
                        Username = c.String(),
                        Disabled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Permissions",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        Code = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CinemaRooms",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        NumberOfSeats = c.Int(nullable: false),
                        Enabled = c.Boolean(nullable: false),
                        CinemaId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cinemas", t => t.CinemaId, cascadeDelete: true)
                .Index(t => t.CinemaId);
            
            CreateTable(
                "dbo.Cinemas",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        Location = c.String(),
                        Enabled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        CinemaId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cinemas", t => t.CinemaId, cascadeDelete: true)
                .Index(t => t.CinemaId);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        StartTime = c.DateTime(nullable: false),
                        CinemaRoomId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CinemaRooms", t => t.CinemaRoomId, cascadeDelete: true)
                .Index(t => t.CinemaRoomId);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Price = c.Double(nullable: false),
                        MovieId = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .ForeignKey("dbo.Administrators", t => t.UserId, cascadeDelete: true)
                .Index(t => t.MovieId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "UserId", "dbo.Administrators");
            DropForeignKey("dbo.Reservations", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.Movies", "CinemaRoomId", "dbo.CinemaRooms");
            DropForeignKey("dbo.Employees", "CinemaId", "dbo.Cinemas");
            DropForeignKey("dbo.CinemaRooms", "CinemaId", "dbo.Cinemas");
            DropForeignKey("dbo.AdministratorPermissions", "PermissionId", "dbo.Permissions");
            DropForeignKey("dbo.AdministratorPermissions", "AdministratorId", "dbo.Administrators");
            DropIndex("dbo.Reservations", new[] { "UserId" });
            DropIndex("dbo.Reservations", new[] { "MovieId" });
            DropIndex("dbo.Movies", new[] { "CinemaRoomId" });
            DropIndex("dbo.Employees", new[] { "CinemaId" });
            DropIndex("dbo.CinemaRooms", new[] { "CinemaId" });
            DropIndex("dbo.AdministratorPermissions", new[] { "PermissionId" });
            DropIndex("dbo.AdministratorPermissions", new[] { "AdministratorId" });
            DropTable("dbo.Reservations");
            DropTable("dbo.Movies");
            DropTable("dbo.Employees");
            DropTable("dbo.Cinemas");
            DropTable("dbo.CinemaRooms");
            DropTable("dbo.Permissions");
            DropTable("dbo.Administrators");
            DropTable("dbo.AdministratorPermissions");
        }
    }
}
