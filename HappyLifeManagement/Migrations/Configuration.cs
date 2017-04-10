namespace HappyLifeManagement.Migrations
{
    using Data;
    using Data.Entity;
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<HappyLifeManagementContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(HappyLifeManagementContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.

            context.ExpenseCategories.AddOrUpdate(
              p => p.Name,
              new ExpenseCategory { Id = Guid.NewGuid(), Name = "Ăn uống" },
              new ExpenseCategory { Id = Guid.NewGuid(), Name = "Đi lại" },
              new ExpenseCategory { Id = Guid.NewGuid(), Name = "Y tế" },
              new ExpenseCategory { Id = Guid.NewGuid(), Name = "Chi tiêu cá nhân" },
              new ExpenseCategory { Id = Guid.NewGuid(), Name = "Giúp đỡ" },
              new ExpenseCategory { Id = Guid.NewGuid(), Name = "Chi phi tiêu dùng" },
              new ExpenseCategory { Id = Guid.NewGuid(), Name = "Giải trí" },
              new ExpenseCategory { Id = Guid.NewGuid(), Name = "Học tập" },
              new ExpenseCategory { Id = Guid.NewGuid(), Name = "Nhu yếu phẩm" }
            );

        }
    }
}
