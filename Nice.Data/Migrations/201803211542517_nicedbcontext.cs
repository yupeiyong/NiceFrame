namespace Nice.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nicedbcontext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sys_DbBackup",
                c => new
                    {
                        F_Id = c.String(nullable: false, maxLength: 128),
                        F_BackupType = c.String(),
                        F_DbName = c.String(),
                        F_FileName = c.String(),
                        F_FileSize = c.String(),
                        F_FilePath = c.String(),
                        F_BackupTime = c.DateTime(),
                        F_SortCode = c.Int(),
                        F_DeleteMark = c.Boolean(),
                        F_EnabledMark = c.Boolean(),
                        F_Description = c.String(),
                        F_CreatorTime = c.DateTime(),
                        F_CreatorUserId = c.String(),
                        F_LastModifyTime = c.DateTime(),
                        F_LastModifyUserId = c.String(),
                        F_DeleteTime = c.DateTime(),
                        F_DeleteUserId = c.String(),
                    })
                .PrimaryKey(t => t.F_Id);
            
            CreateTable(
                "dbo.Sys_FilterIP",
                c => new
                    {
                        F_Id = c.String(nullable: false, maxLength: 128),
                        F_Type = c.Boolean(),
                        F_StartIP = c.String(),
                        F_EndIP = c.String(),
                        F_SortCode = c.Int(),
                        F_DeleteMark = c.Boolean(),
                        F_EnabledMark = c.Boolean(),
                        F_Description = c.String(),
                        F_CreatorTime = c.DateTime(),
                        F_CreatorUserId = c.String(),
                        F_LastModifyTime = c.DateTime(),
                        F_LastModifyUserId = c.String(),
                        F_DeleteTime = c.DateTime(),
                        F_DeleteUserId = c.String(),
                    })
                .PrimaryKey(t => t.F_Id);
            
            CreateTable(
                "dbo.Sys_Log",
                c => new
                    {
                        F_Id = c.String(nullable: false, maxLength: 128),
                        F_Date = c.DateTime(),
                        F_Account = c.String(),
                        F_NickName = c.String(),
                        F_Type = c.String(),
                        F_IPAddress = c.String(),
                        F_IPAddressName = c.String(),
                        F_ModuleId = c.String(),
                        F_ModuleName = c.String(),
                        F_Result = c.Boolean(),
                        F_Description = c.String(),
                        F_CreatorTime = c.DateTime(),
                        F_CreatorUserId = c.String(),
                    })
                .PrimaryKey(t => t.F_Id);
            
            CreateTable(
                "dbo.Sys_Area",
                c => new
                    {
                        F_Id = c.String(nullable: false, maxLength: 128),
                        F_ParentId = c.String(),
                        F_Layers = c.Int(),
                        F_EnCode = c.String(),
                        F_FullName = c.String(),
                        F_SimpleSpelling = c.String(),
                        F_SortCode = c.Int(),
                        F_DeleteMark = c.Boolean(),
                        F_EnabledMark = c.Boolean(),
                        F_Description = c.String(),
                        F_CreatorTime = c.DateTime(),
                        F_CreatorUserId = c.String(),
                        F_LastModifyTime = c.DateTime(),
                        F_LastModifyUserId = c.String(),
                        F_DeleteTime = c.DateTime(),
                        F_DeleteUserId = c.String(),
                    })
                .PrimaryKey(t => t.F_Id);
            
            CreateTable(
                "dbo.Sys_ItemsDetail",
                c => new
                    {
                        F_Id = c.String(nullable: false, maxLength: 128),
                        F_ItemId = c.String(),
                        F_ParentId = c.String(),
                        F_ItemCode = c.String(),
                        F_ItemName = c.String(),
                        F_SimpleSpelling = c.String(),
                        F_IsDefault = c.Boolean(),
                        F_Layers = c.Int(),
                        F_SortCode = c.Int(),
                        F_DeleteMark = c.Boolean(),
                        F_EnabledMark = c.Boolean(),
                        F_Description = c.String(),
                        F_CreatorTime = c.DateTime(),
                        F_CreatorUserId = c.String(),
                        F_LastModifyTime = c.DateTime(),
                        F_LastModifyUserId = c.String(),
                        F_DeleteTime = c.DateTime(),
                        F_DeleteUserId = c.String(),
                    })
                .PrimaryKey(t => t.F_Id);
            
            CreateTable(
                "dbo.Sys_Items",
                c => new
                    {
                        F_Id = c.String(nullable: false, maxLength: 128),
                        F_ParentId = c.String(),
                        F_EnCode = c.String(),
                        F_FullName = c.String(),
                        F_IsTree = c.Boolean(),
                        F_Layers = c.Int(),
                        F_SortCode = c.Int(),
                        F_DeleteMark = c.Boolean(),
                        F_EnabledMark = c.Boolean(),
                        F_Description = c.String(),
                        F_CreatorTime = c.DateTime(),
                        F_CreatorUserId = c.String(),
                        F_LastModifyTime = c.DateTime(),
                        F_LastModifyUserId = c.String(),
                        F_DeleteTime = c.DateTime(),
                        F_DeleteUserId = c.String(),
                    })
                .PrimaryKey(t => t.F_Id);
            
            CreateTable(
                "dbo.Sys_ModuleButton",
                c => new
                    {
                        F_Id = c.String(nullable: false, maxLength: 128),
                        F_ModuleId = c.String(),
                        F_ParentId = c.String(),
                        F_Layers = c.Int(),
                        F_EnCode = c.String(),
                        F_FullName = c.String(),
                        F_Icon = c.String(),
                        F_Location = c.Int(),
                        F_JsEvent = c.String(),
                        F_UrlAddress = c.String(),
                        F_Split = c.Boolean(),
                        F_IsPublic = c.Boolean(),
                        F_AllowEdit = c.Boolean(),
                        F_AllowDelete = c.Boolean(),
                        F_SortCode = c.Int(),
                        F_DeleteMark = c.Boolean(),
                        F_EnabledMark = c.Boolean(),
                        F_Description = c.String(),
                        F_CreatorTime = c.DateTime(),
                        F_CreatorUserId = c.String(),
                        F_LastModifyTime = c.DateTime(),
                        F_LastModifyUserId = c.String(),
                        F_DeleteTime = c.DateTime(),
                        F_DeleteUserId = c.String(),
                    })
                .PrimaryKey(t => t.F_Id);
            
            CreateTable(
                "dbo.Sys_Module",
                c => new
                    {
                        F_Id = c.String(nullable: false, maxLength: 128),
                        F_ParentId = c.String(),
                        F_Layers = c.Int(),
                        F_EnCode = c.String(),
                        F_FullName = c.String(),
                        F_Icon = c.String(),
                        F_UrlAddress = c.String(),
                        F_Target = c.String(),
                        F_IsMenu = c.Boolean(),
                        F_IsExpand = c.Boolean(),
                        F_IsPublic = c.Boolean(),
                        F_AllowEdit = c.Boolean(),
                        F_AllowDelete = c.Boolean(),
                        F_SortCode = c.Int(),
                        F_DeleteMark = c.Boolean(),
                        F_EnabledMark = c.Boolean(),
                        F_Description = c.String(),
                        F_CreatorTime = c.DateTime(),
                        F_CreatorUserId = c.String(),
                        F_LastModifyTime = c.DateTime(),
                        F_LastModifyUserId = c.String(),
                        F_DeleteTime = c.DateTime(),
                        F_DeleteUserId = c.String(),
                    })
                .PrimaryKey(t => t.F_Id);
            
            CreateTable(
                "dbo.Sys_Organize",
                c => new
                    {
                        F_Id = c.String(nullable: false, maxLength: 128),
                        F_ParentId = c.String(),
                        F_Layers = c.Int(),
                        F_EnCode = c.String(),
                        F_FullName = c.String(),
                        F_ShortName = c.String(),
                        F_CategoryId = c.String(),
                        F_ManagerId = c.String(),
                        F_TelePhone = c.String(),
                        F_MobilePhone = c.String(),
                        F_WeChat = c.String(),
                        F_Fax = c.String(),
                        F_Email = c.String(),
                        F_AreaId = c.String(),
                        F_Address = c.String(),
                        F_AllowEdit = c.Boolean(),
                        F_AllowDelete = c.Boolean(),
                        F_SortCode = c.Int(),
                        F_DeleteMark = c.Boolean(),
                        F_EnabledMark = c.Boolean(),
                        F_Description = c.String(),
                        F_CreatorTime = c.DateTime(),
                        F_CreatorUserId = c.String(),
                        F_LastModifyTime = c.DateTime(),
                        F_LastModifyUserId = c.String(),
                        F_DeleteTime = c.DateTime(),
                        F_DeleteUserId = c.String(),
                    })
                .PrimaryKey(t => t.F_Id);
            
            CreateTable(
                "dbo.Sys_RoleAuthorize",
                c => new
                    {
                        F_Id = c.String(nullable: false, maxLength: 128),
                        F_ItemType = c.Int(),
                        F_ItemId = c.String(),
                        F_ObjectType = c.Int(),
                        F_ObjectId = c.String(),
                        F_SortCode = c.Int(),
                        F_CreatorTime = c.DateTime(),
                        F_CreatorUserId = c.String(),
                    })
                .PrimaryKey(t => t.F_Id);
            
            CreateTable(
                "dbo.Sys_Role",
                c => new
                    {
                        F_Id = c.String(nullable: false, maxLength: 128),
                        F_OrganizeId = c.String(),
                        F_Category = c.Int(),
                        F_EnCode = c.String(),
                        F_FullName = c.String(),
                        F_Type = c.String(),
                        F_AllowEdit = c.Boolean(),
                        F_AllowDelete = c.Boolean(),
                        F_SortCode = c.Int(),
                        F_DeleteMark = c.Boolean(),
                        F_EnabledMark = c.Boolean(),
                        F_Description = c.String(),
                        F_CreatorTime = c.DateTime(),
                        F_CreatorUserId = c.String(),
                        F_LastModifyTime = c.DateTime(),
                        F_LastModifyUserId = c.String(),
                        F_DeleteTime = c.DateTime(),
                        F_DeleteUserId = c.String(),
                    })
                .PrimaryKey(t => t.F_Id);
            
            CreateTable(
                "dbo.Sys_UserLogOn",
                c => new
                    {
                        F_Id = c.String(nullable: false, maxLength: 128),
                        F_UserId = c.String(),
                        F_UserPassword = c.String(),
                        F_UserSecretkey = c.String(),
                        F_AllowStartTime = c.DateTime(),
                        F_AllowEndTime = c.DateTime(),
                        F_LockStartDate = c.DateTime(),
                        F_LockEndDate = c.DateTime(),
                        F_FirstVisitTime = c.DateTime(),
                        F_PreviousVisitTime = c.DateTime(),
                        F_LastVisitTime = c.DateTime(),
                        F_ChangePasswordDate = c.DateTime(),
                        F_MultiUserLogin = c.Boolean(),
                        F_LogOnCount = c.Int(),
                        F_UserOnLine = c.Boolean(),
                        F_Question = c.String(),
                        F_AnswerQuestion = c.String(),
                        F_CheckIPAddress = c.Boolean(),
                        F_Language = c.String(),
                        F_Theme = c.String(),
                    })
                .PrimaryKey(t => t.F_Id);
            
            CreateTable(
                "dbo.Sys_User",
                c => new
                    {
                        F_Id = c.String(nullable: false, maxLength: 128),
                        F_Account = c.String(),
                        F_RealName = c.String(),
                        F_NickName = c.String(),
                        F_HeadIcon = c.String(),
                        F_Gender = c.Boolean(),
                        F_Birthday = c.DateTime(),
                        F_MobilePhone = c.String(),
                        F_Email = c.String(),
                        F_WeChat = c.String(),
                        F_ManagerId = c.String(),
                        F_SecurityLevel = c.Int(),
                        F_Signature = c.String(),
                        F_OrganizeId = c.String(),
                        F_DepartmentId = c.String(),
                        F_RoleId = c.String(),
                        F_DutyId = c.String(),
                        F_IsAdministrator = c.Boolean(),
                        F_SortCode = c.Int(),
                        F_DeleteMark = c.Boolean(),
                        F_EnabledMark = c.Boolean(),
                        F_Description = c.String(),
                        F_CreatorTime = c.DateTime(),
                        F_CreatorUserId = c.String(),
                        F_LastModifyTime = c.DateTime(),
                        F_LastModifyUserId = c.String(),
                        F_DeleteTime = c.DateTime(),
                        F_DeleteUserId = c.String(),
                    })
                .PrimaryKey(t => t.F_Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Sys_User");
            DropTable("dbo.Sys_UserLogOn");
            DropTable("dbo.Sys_Role");
            DropTable("dbo.Sys_RoleAuthorize");
            DropTable("dbo.Sys_Organize");
            DropTable("dbo.Sys_Module");
            DropTable("dbo.Sys_ModuleButton");
            DropTable("dbo.Sys_Items");
            DropTable("dbo.Sys_ItemsDetail");
            DropTable("dbo.Sys_Area");
            DropTable("dbo.Sys_Log");
            DropTable("dbo.Sys_FilterIP");
            DropTable("dbo.Sys_DbBackup");
        }
    }
}
