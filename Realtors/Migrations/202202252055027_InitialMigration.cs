namespace Realtors.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BuildingMaterials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Districts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EvaluationCriteria",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Evaluations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RealEstateId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        EvaluationCriteriaId = c.Int(nullable: false),
                        Rating = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EvaluationCriteria", t => t.EvaluationCriteriaId, cascadeDelete: true)
                .ForeignKey("dbo.RealEstate", t => t.RealEstateId, cascadeDelete: true)
                .Index(t => t.RealEstateId)
                .Index(t => t.EvaluationCriteriaId);
            
            CreateTable(
                "dbo.RealEstate",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DistrictId = c.Int(nullable: false),
                        Address = c.String(),
                        Floor = c.Int(nullable: false),
                        RoomsCount = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                        Description = c.String(),
                        BuildingMaterialId = c.Int(nullable: false),
                        Square = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BuildingMaterials", t => t.BuildingMaterialId, cascadeDelete: true)
                .ForeignKey("dbo.Districts", t => t.DistrictId, cascadeDelete: true)
                .Index(t => t.DistrictId)
                .Index(t => t.BuildingMaterialId);
            
            CreateTable(
                "dbo.Realtors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LastName = c.String(),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RealEstateId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        RealtorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RealEstate", t => t.RealEstateId, cascadeDelete: true)
                .ForeignKey("dbo.Realtors", t => t.RealtorId, cascadeDelete: true)
                .Index(t => t.RealEstateId)
                .Index(t => t.RealtorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sales", "RealtorId", "dbo.Realtors");
            DropForeignKey("dbo.Sales", "RealEstateId", "dbo.RealEstate");
            DropForeignKey("dbo.Evaluations", "RealEstateId", "dbo.RealEstate");
            DropForeignKey("dbo.RealEstate", "DistrictId", "dbo.Districts");
            DropForeignKey("dbo.RealEstate", "BuildingMaterialId", "dbo.BuildingMaterials");
            DropForeignKey("dbo.Evaluations", "EvaluationCriteriaId", "dbo.EvaluationCriteria");
            DropIndex("dbo.Sales", new[] { "RealtorId" });
            DropIndex("dbo.Sales", new[] { "RealEstateId" });
            DropIndex("dbo.RealEstate", new[] { "BuildingMaterialId" });
            DropIndex("dbo.RealEstate", new[] { "DistrictId" });
            DropIndex("dbo.Evaluations", new[] { "EvaluationCriteriaId" });
            DropIndex("dbo.Evaluations", new[] { "RealEstateId" });
            DropTable("dbo.Sales");
            DropTable("dbo.Realtors");
            DropTable("dbo.RealEstate");
            DropTable("dbo.Evaluations");
            DropTable("dbo.EvaluationCriteria");
            DropTable("dbo.Districts");
            DropTable("dbo.BuildingMaterials");
        }
    }
}
