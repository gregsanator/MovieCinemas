namespace MovieCinemas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFoodProductsModelAndAddFoodPackagesModelAndAddFoodPackagesFoodProductsModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FoodPackages",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Price = c.Double(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FoodProducts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FoodProductsFoodPackages",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FoodProductId = c.Guid(nullable: false),
                        FoodPackageId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FoodPackages", t => t.FoodPackageId, cascadeDelete: true)
                .ForeignKey("dbo.FoodProducts", t => t.FoodProductId, cascadeDelete: true)
                .Index(t => t.FoodProductId)
                .Index(t => t.FoodPackageId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FoodProductsFoodPackages", "FoodProductId", "dbo.FoodProducts");
            DropForeignKey("dbo.FoodProductsFoodPackages", "FoodPackageId", "dbo.FoodPackages");
            DropIndex("dbo.FoodProductsFoodPackages", new[] { "FoodPackageId" });
            DropIndex("dbo.FoodProductsFoodPackages", new[] { "FoodProductId" });
            DropTable("dbo.FoodProductsFoodPackages");
            DropTable("dbo.FoodProducts");
            DropTable("dbo.FoodPackages");
        }
    }
}
