namespace ProjectHuman.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PetTypes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HumanChildren",
                c => new
                    {
                        HumanId = c.Guid(nullable: false),
                        Child = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.HumanId, t.Child })
                .ForeignKey("dbo.Human", t => t.HumanId)
                .ForeignKey("dbo.Human", t => t.Child)
                .Index(t => t.HumanId)
                .Index(t => t.Child);
            
            CreateTable(
                "dbo.HumanFriends",
                c => new
                    {
                        HumanId = c.Guid(nullable: false),
                        FriendsWith = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.HumanId, t.FriendsWith })
                .ForeignKey("dbo.Human", t => t.HumanId)
                .ForeignKey("dbo.Human", t => t.FriendsWith)
                .Index(t => t.HumanId)
                .Index(t => t.FriendsWith);
            
            CreateTable(
                "dbo.Human",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Reproduction = c.Int(nullable: false),
                        Height = c.Double(nullable: false),
                        Weight = c.Double(nullable: false),
                        Birthdate = c.DateTime(nullable: false),
                        Sex = c.Int(nullable: false),
                        State = c.Int(nullable: false),
                        Firstname = c.String(name: "First name", maxLength: 4000),
                        Lastname = c.String(name: "Last name", maxLength: 4000),
                        MotherId = c.Guid(),
                        FatherId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pets",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Owner_Id = c.Guid(),
                        PetType_Id = c.Guid(),
                        Reproduction = c.Int(nullable: false),
                        Height = c.Double(nullable: false),
                        Weight = c.Double(nullable: false),
                        Birthdate = c.DateTime(nullable: false),
                        Sex = c.Int(nullable: false),
                        State = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Human", t => t.Owner_Id)
                .ForeignKey("dbo.PetTypes", t => t.PetType_Id)
                .Index(t => t.Owner_Id)
                .Index(t => t.PetType_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pets", "PetType_Id", "dbo.PetTypes");
            DropForeignKey("dbo.Pets", "Owner_Id", "dbo.Human");
            DropForeignKey("dbo.HumanFriends", "FriendsWith", "dbo.Human");
            DropForeignKey("dbo.HumanFriends", "HumanId", "dbo.Human");
            DropForeignKey("dbo.HumanChildren", "Child", "dbo.Human");
            DropForeignKey("dbo.HumanChildren", "HumanId", "dbo.Human");
            DropIndex("dbo.Pets", new[] { "PetType_Id" });
            DropIndex("dbo.Pets", new[] { "Owner_Id" });
            DropIndex("dbo.HumanFriends", new[] { "FriendsWith" });
            DropIndex("dbo.HumanFriends", new[] { "HumanId" });
            DropIndex("dbo.HumanChildren", new[] { "Child" });
            DropIndex("dbo.HumanChildren", new[] { "HumanId" });
            DropTable("dbo.Pets");
            DropTable("dbo.Human");
            DropTable("dbo.HumanFriends");
            DropTable("dbo.HumanChildren");
            DropTable("dbo.PetTypes");
        }
    }
}
