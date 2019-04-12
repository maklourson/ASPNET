namespace GestionDesCourses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testbeta3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Races",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateEnd = c.DateTime(nullable: false),
                        DateStart = c.DateTime(nullable: false),
                        Description = c.String(nullable: false, maxLength: 200),
                        Price = c.Single(nullable: false),
                        Title = c.String(nullable: false, maxLength: 25),
                        ZipCode = c.String(nullable: false),
                        Category_Id = c.Int(nullable: false),
                        Poi_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id, cascadeDelete: true)
                .ForeignKey("dbo.Pois", t => t.Poi_Id)
                .Index(t => t.Category_Id)
                .Index(t => t.Poi_Id);
            
            CreateTable(
                "dbo.Inscriptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Single(nullable: false),
                        IdentityModelId = c.String(),
                        RaceId = c.Int(nullable: false),
                        RaceTitle = c.String(),
                        RaceStart = c.DateTime(nullable: false),
                        RaceEnd = c.DateTime(nullable: false),
                        TypeInscriptionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Races", t => t.RaceId, cascadeDelete: true)
                .Index(t => t.RaceId);
            
            CreateTable(
                "dbo.Pois",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DisplayConfigurations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DeviceName = c.String(),
                        SpeedAvg = c.Boolean(nullable: false),
                        SpeedMax = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.TypeInscriptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UniteDistances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        unite = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameRole = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        BirthDate = c.DateTime(),
                        RoleUser = c.String(),
                        RoleAdministrateur = c.String(),
                        RoleSuperAdministrateur = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.RacePois",
                c => new
                    {
                        Race_Id = c.Int(nullable: false),
                        Poi_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Race_Id, t.Poi_Id })
                .ForeignKey("dbo.Races", t => t.Race_Id, cascadeDelete: true)
                .ForeignKey("dbo.Pois", t => t.Poi_Id, cascadeDelete: true)
                .Index(t => t.Race_Id)
                .Index(t => t.Poi_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.RacePois", "Poi_Id", "dbo.Pois");
            DropForeignKey("dbo.RacePois", "Race_Id", "dbo.Races");
            DropForeignKey("dbo.Races", "Poi_Id", "dbo.Pois");
            DropForeignKey("dbo.Inscriptions", "RaceId", "dbo.Races");
            DropForeignKey("dbo.Races", "Category_Id", "dbo.Categories");
            DropIndex("dbo.RacePois", new[] { "Poi_Id" });
            DropIndex("dbo.RacePois", new[] { "Race_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Inscriptions", new[] { "RaceId" });
            DropIndex("dbo.Races", new[] { "Poi_Id" });
            DropIndex("dbo.Races", new[] { "Category_Id" });
            DropTable("dbo.RacePois");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.UserRoles");
            DropTable("dbo.UniteDistances");
            DropTable("dbo.TypeInscriptions");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.DisplayConfigurations");
            DropTable("dbo.Pois");
            DropTable("dbo.Inscriptions");
            DropTable("dbo.Races");
            DropTable("dbo.Categories");
        }
    }
}
