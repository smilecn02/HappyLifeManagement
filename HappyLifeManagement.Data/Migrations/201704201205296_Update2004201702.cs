namespace HappyLifeManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update2004201702 : DbMigration
    {
        public override void Up()
        {
            Sql("Update Expense set UserId = (select Id from AspNetUsers where Email = 'khactrinhcn02@gmail.com') where UserId is null");
        }
        
        public override void Down()
        {
            Sql("Update Expense set UserId = null where UserId in (select Id from AspNetUsers where Email = 'khactrinhcn02@gmail.com')");
        }
    }
}
