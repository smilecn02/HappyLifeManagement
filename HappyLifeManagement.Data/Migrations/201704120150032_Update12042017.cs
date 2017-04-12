namespace HappyLifeManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update12042017 : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.ExpenseCategory",
            //    c => new
            //        {
            //            Id = c.Guid(nullable: false),
            //            Name = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.Expense",
            //    c => new
            //        {
            //            Id = c.Guid(nullable: false),
            //            ExpenseDate = c.DateTime(nullable: false),
            //            Name = c.String(),
            //            Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            Location = c.String(),
            //            ExpenseCategoryId = c.Guid(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.ExpenseCategory", t => t.ExpenseCategoryId, cascadeDelete: true)
            //    .Index(t => t.ExpenseCategoryId);
            
            //CreateTable(
            //    "dbo.Note",
            //    c => new
            //        {
            //            Id = c.Guid(nullable: false),
            //            Title = c.String(),
            //            Content = c.String(),
            //            Tags = c.String(),
            //            CreatedDate = c.DateTime(),
            //            UpdatedDate = c.DateTime(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.Expense", "ExpenseCategoryId", "dbo.ExpenseCategory");
            //DropIndex("dbo.Expense", new[] { "ExpenseCategoryId" });
            //DropTable("dbo.Note");
            //DropTable("dbo.Expense");
            //DropTable("dbo.ExpenseCategory");
        }
    }
}
