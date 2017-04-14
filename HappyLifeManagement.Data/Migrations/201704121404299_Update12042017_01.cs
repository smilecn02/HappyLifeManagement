namespace HappyLifeManagement.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Update12042017_01 : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.Expense", "Note", c => c.String());
            //DropColumn("dbo.Expense", "Location");

            RenameColumn("dbo.Expense", "Location", "Note");
        }
        
        public override void Down()
        {
            //AddColumn("dbo.Expense", "Location", c => c.String());
            //DropColumn("dbo.Expense", "Note");

            RenameColumn("dbo.Expense", "Note", "Location");
        }
    }
}
