namespace SuggestionSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Degrees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 50),
                        Checked = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PersonProfiles",
                c => new
                    {
                        PersonProfileId = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false),
                        FatherName = c.String(nullable: false),
                        NationalCode = c.String(nullable: false, maxLength: 10),
                        Mobile = c.String(nullable: false, maxLength: 11),
                        BirthDate = c.String(maxLength: 10),
                        Image = c.String(maxLength: 500),
                        Reshte = c.String(nullable: false, maxLength: 150),
                        DateUpload = c.String(maxLength: 10),
                        TimeUpload = c.String(maxLength: 10),
                        DateEdit = c.String(maxLength: 10),
                        TImeEdit = c.String(maxLength: 10),
                        Phone = c.String(maxLength: 11),
                        DegreeId = c.Int(),
                        PostId = c.Int(),
                        Email = c.String(),
                        ID_MemType = c.Int(),
                        PostOrgans = c.String(maxLength: 250),
                        Isshow = c.Boolean(),
                        Password = c.String(nullable: false),
                        ConfirmPassword = c.String(),
                        OtherMem = c.String(),
                        MemberType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.PersonProfileId)
                .ForeignKey("dbo.Degrees", t => t.DegreeId)
                .ForeignKey("dbo.MemberType", t => t.MemberType_Id)
                .ForeignKey("dbo.Posts", t => t.PostId)
                .Index(t => t.DegreeId)
                .Index(t => t.PostId)
                .Index(t => t.MemberType_Id);
            
            CreateTable(
                "dbo.MemberType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SuggestProfils",
                c => new
                    {
                        SuggestId = c.Int(nullable: false, identity: true),
                        Benefits = c.String(),
                        SuggestTitle = c.String(),
                        Issms = c.Boolean(nullable: false),
                        IsEditedSugg = c.Boolean(nullable: false),
                        SuggestNote = c.String(),
                        CurrentSituationNote = c.String(),
                        Result = c.String(),
                        Cost = c.String(),
                        UnitTypeId = c.Int(),
                        ID_DomainOfUsage = c.Int(),
                        PersonProfileId = c.Int(),
                        DateInsert = c.String(),
                        PeriodOfTime = c.Int(nullable: false),
                        Note_Cost = c.String(),
                        Equipment = c.String(),
                        TimeInsert = c.String(maxLength: 250),
                        UserInsert = c.String(maxLength: 250),
                        LastTime = c.String(maxLength: 250),
                        LastDate = c.String(maxLength: 250),
                        IsShow = c.Boolean(),
                        IsInvitation = c.Boolean(nullable: false),
                        ID_Invitation = c.Int(),
                        OtherMem = c.String(),
                        ID_PeopleType = c.Int(),
                        DomainOfUsage_Id = c.Int(),
                        Invitatin_Id = c.Int(),
                        PeopleType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.SuggestId)
                .ForeignKey("dbo.DomainOfUsages", t => t.DomainOfUsage_Id)
                .ForeignKey("dbo.Invitatins", t => t.Invitatin_Id)
                .ForeignKey("dbo.PeopleTypes", t => t.PeopleType_Id)
                .ForeignKey("dbo.PersonProfiles", t => t.PersonProfileId)
                .Index(t => t.PersonProfileId)
                .Index(t => t.DomainOfUsage_Id)
                .Index(t => t.Invitatin_Id)
                .Index(t => t.PeopleType_Id);
            
            CreateTable(
                "dbo.DomainOfUsages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FileUploads",
                c => new
                    {
                        FileId = c.Int(nullable: false, identity: true),
                        Address = c.String(maxLength: 500),
                        SuggestId = c.Int(),
                        Time = c.String(maxLength: 50),
                        Date = c.String(maxLength: 50),
                        FileName = c.String(),
                        Weight = c.Int(nullable: false),
                        PersonProfileId = c.Int(),
                        mimetype = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.FileId)
                .ForeignKey("dbo.SuggestProfils", t => t.SuggestId)
                .Index(t => t.SuggestId);
            
            CreateTable(
                "dbo.Invitatins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 50),
                        IsActive = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ParticipatingUnits_Suggest_Interface",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SuggestId = c.Int(),
                        ID_PartiCipatingU = c.Int(),
                        LastTime = c.String(maxLength: 50),
                        LastDate = c.String(maxLength: 50),
                        ParticipatingUnit_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ParticipatingUnits", t => t.ParticipatingUnit_Id)
                .ForeignKey("dbo.SuggestProfils", t => t.SuggestId)
                .Index(t => t.SuggestId)
                .Index(t => t.ParticipatingUnit_Id);
            
            CreateTable(
                "dbo.ParticipatingUnits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 50),
                        Checked = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PeopleTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SuggProfile_SuggType_Interface",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ID_SuggType = c.Int(),
                        ID_SuggTypeRefree = c.Int(),
                        ID_SuggProfile = c.Int(),
                        User_Secretariate = c.String(),
                        Date_Secretariate = c.String(),
                        time_Secretariate = c.String(),
                        Edit_Date_Secretariate = c.String(),
                        Edit_Time_Secretariate = c.String(),
                        Edit_User_Secretariate = c.String(),
                        Date = c.String(),
                        Date_Referee = c.String(),
                        User_Referee = c.String(),
                        Time_Referee = c.String(),
                        Edit_Time_Referee = c.String(),
                        Edit_Date_Referee = c.String(),
                        Edit_User_Referee = c.String(),
                        LetterNumber = c.String(maxLength: 50),
                        Note_Secretariate = c.String(),
                        Note_Referee = c.String(),
                        Point = c.Int(),
                        IsActive = c.Boolean(nullable: false),
                        IsRefree = c.Boolean(nullable: false),
                        IsEdited = c.Boolean(nullable: false),
                        RefreeSms = c.Boolean(nullable: false),
                        SecreSms = c.Boolean(nullable: false),
                        ID_Part = c.Int(),
                        PartType_Id = c.Int(),
                        SuggestProfil_SuggestId = c.Int(),
                        SuggestType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.PartTypes", t => t.PartType_Id)
                .ForeignKey("dbo.SuggestProfils", t => t.SuggestProfil_SuggestId)
                .ForeignKey("dbo.SuggestTypes", t => t.SuggestType_Id)
                .Index(t => t.PartType_Id)
                .Index(t => t.SuggestProfil_SuggestId)
                .Index(t => t.SuggestType_Id);
            
            CreateTable(
                "dbo.PartTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SuggestTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 50),
                        Step = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UnitType_Suggest_Interface",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SuggestId = c.Int(),
                        ID_UnitType = c.Int(),
                        LastTime = c.String(maxLength: 50),
                        LastDate = c.String(maxLength: 50),
                        UnitType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SuggestProfils", t => t.SuggestId)
                .ForeignKey("dbo.UnitTypes", t => t.UnitType_Id)
                .Index(t => t.SuggestId)
                .Index(t => t.UnitType_Id);
            
            CreateTable(
                "dbo.UnitTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 50),
                        Checked = c.Boolean(nullable: false),
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
                "dbo.TitlLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 50),
                        Checked = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.UnitType_Suggest_Interface", "UnitType_Id", "dbo.UnitTypes");
            DropForeignKey("dbo.UnitType_Suggest_Interface", "SuggestId", "dbo.SuggestProfils");
            DropForeignKey("dbo.SuggProfile_SuggType_Interface", "SuggestType_Id", "dbo.SuggestTypes");
            DropForeignKey("dbo.SuggProfile_SuggType_Interface", "SuggestProfil_SuggestId", "dbo.SuggestProfils");
            DropForeignKey("dbo.SuggProfile_SuggType_Interface", "PartType_Id", "dbo.PartTypes");
            DropForeignKey("dbo.SuggestProfils", "PersonProfileId", "dbo.PersonProfiles");
            DropForeignKey("dbo.SuggestProfils", "PeopleType_Id", "dbo.PeopleTypes");
            DropForeignKey("dbo.ParticipatingUnits_Suggest_Interface", "SuggestId", "dbo.SuggestProfils");
            DropForeignKey("dbo.ParticipatingUnits_Suggest_Interface", "ParticipatingUnit_Id", "dbo.ParticipatingUnits");
            DropForeignKey("dbo.SuggestProfils", "Invitatin_Id", "dbo.Invitatins");
            DropForeignKey("dbo.FileUploads", "SuggestId", "dbo.SuggestProfils");
            DropForeignKey("dbo.SuggestProfils", "DomainOfUsage_Id", "dbo.DomainOfUsages");
            DropForeignKey("dbo.PersonProfiles", "PostId", "dbo.Posts");
            DropForeignKey("dbo.PersonProfiles", "MemberType_Id", "dbo.MemberType");
            DropForeignKey("dbo.PersonProfiles", "DegreeId", "dbo.Degrees");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.UnitType_Suggest_Interface", new[] { "UnitType_Id" });
            DropIndex("dbo.UnitType_Suggest_Interface", new[] { "SuggestId" });
            DropIndex("dbo.SuggProfile_SuggType_Interface", new[] { "SuggestType_Id" });
            DropIndex("dbo.SuggProfile_SuggType_Interface", new[] { "SuggestProfil_SuggestId" });
            DropIndex("dbo.SuggProfile_SuggType_Interface", new[] { "PartType_Id" });
            DropIndex("dbo.ParticipatingUnits_Suggest_Interface", new[] { "ParticipatingUnit_Id" });
            DropIndex("dbo.ParticipatingUnits_Suggest_Interface", new[] { "SuggestId" });
            DropIndex("dbo.FileUploads", new[] { "SuggestId" });
            DropIndex("dbo.SuggestProfils", new[] { "PeopleType_Id" });
            DropIndex("dbo.SuggestProfils", new[] { "Invitatin_Id" });
            DropIndex("dbo.SuggestProfils", new[] { "DomainOfUsage_Id" });
            DropIndex("dbo.SuggestProfils", new[] { "PersonProfileId" });
            DropIndex("dbo.PersonProfiles", new[] { "MemberType_Id" });
            DropIndex("dbo.PersonProfiles", new[] { "PostId" });
            DropIndex("dbo.PersonProfiles", new[] { "DegreeId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.TitlLists");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.UnitTypes");
            DropTable("dbo.UnitType_Suggest_Interface");
            DropTable("dbo.SuggestTypes");
            DropTable("dbo.PartTypes");
            DropTable("dbo.SuggProfile_SuggType_Interface");
            DropTable("dbo.PeopleTypes");
            DropTable("dbo.ParticipatingUnits");
            DropTable("dbo.ParticipatingUnits_Suggest_Interface");
            DropTable("dbo.Invitatins");
            DropTable("dbo.FileUploads");
            DropTable("dbo.DomainOfUsages");
            DropTable("dbo.SuggestProfils");
            DropTable("dbo.Posts");
            DropTable("dbo.MemberType");
            DropTable("dbo.PersonProfiles");
            DropTable("dbo.Degrees");
        }
    }
}
