namespace MovieCinemas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddClubCardsModelAndAddAdministratorFKToTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClubCards",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        AdministratorId = c.Guid(),
                        UserId = c.Guid(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        Points = c.Double(nullable: false),
                        Enabled = c.Boolean(nullable: false),
                        DiscountPercantage = c.Double(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Administrators", t => t.AdministratorId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.AdministratorId)
                .Index(t => t.UserId);
            
            AddColumn("dbo.CinemaRooms", "AdministratorId", c => c.Guid(nullable: false));
            AddColumn("dbo.Cinemas", "AdministratorId", c => c.Guid(nullable: false));
            AddColumn("dbo.Employees", "AdministratorId", c => c.Guid(nullable: false));
            AddColumn("dbo.Movies", "AdministratorId", c => c.Guid(nullable: false));
            AddColumn("dbo.Users", "AdministratorId", c => c.Guid(nullable: false));
            CreateIndex("dbo.CinemaRooms", "AdministratorId");
            CreateIndex("dbo.Cinemas", "AdministratorId");
            CreateIndex("dbo.Users", "AdministratorId");
            CreateIndex("dbo.Employees", "AdministratorId");
            CreateIndex("dbo.Movies", "AdministratorId");
            AddForeignKey("dbo.CinemaRooms", "AdministratorId", "dbo.Administrators", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Cinemas", "AdministratorId", "dbo.Administrators", "Id");
            AddForeignKey("dbo.Users", "AdministratorId", "dbo.Administrators", "Id");
            AddForeignKey("dbo.Employees", "AdministratorId", "dbo.Administrators", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Movies", "AdministratorId", "dbo.Administrators", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "AdministratorId", "dbo.Administrators");
            DropForeignKey("dbo.Employees", "AdministratorId", "dbo.Administrators");
            DropForeignKey("dbo.ClubCards", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "AdministratorId", "dbo.Administrators");
            DropForeignKey("dbo.ClubCards", "AdministratorId", "dbo.Administrators");
            DropForeignKey("dbo.Cinemas", "AdministratorId", "dbo.Administrators");
            DropForeignKey("dbo.CinemaRooms", "AdministratorId", "dbo.Administrators");
            DropIndex("dbo.Movies", new[] { "AdministratorId" });
            DropIndex("dbo.Employees", new[] { "AdministratorId" });
            DropIndex("dbo.Users", new[] { "AdministratorId" });
            DropIndex("dbo.ClubCards", new[] { "UserId" });
            DropIndex("dbo.ClubCards", new[] { "AdministratorId" });
            DropIndex("dbo.Cinemas", new[] { "AdministratorId" });
            DropIndex("dbo.CinemaRooms", new[] { "AdministratorId" });
            DropColumn("dbo.Users", "AdministratorId");
            DropColumn("dbo.Movies", "AdministratorId");
            DropColumn("dbo.Employees", "AdministratorId");
            DropColumn("dbo.Cinemas", "AdministratorId");
            DropColumn("dbo.CinemaRooms", "AdministratorId");
            DropTable("dbo.ClubCards");
        }
    }
}
