namespace MovieCinemas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUsers : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reservations", "UserId", "dbo.Administrators");
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Surname = c.String(),
                        Birthday = c.DateTime(nullable: false),
                        UserName = c.String(),
                        Enabled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Reservations", "ReservationDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Reservations", "AdministratorId", c => c.Guid());
            CreateIndex("dbo.Reservations", "AdministratorId");
            AddForeignKey("dbo.Reservations", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Reservations", "AdministratorId", "dbo.Administrators", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "AdministratorId", "dbo.Administrators");
            DropForeignKey("dbo.Reservations", "UserId", "dbo.Users");
            DropIndex("dbo.Reservations", new[] { "AdministratorId" });
            DropColumn("dbo.Reservations", "AdministratorId");
            DropColumn("dbo.Reservations", "ReservationDate");
            DropTable("dbo.Users");
            AddForeignKey("dbo.Reservations", "UserId", "dbo.Administrators", "Id", cascadeDelete: true);
        }
    }
}
