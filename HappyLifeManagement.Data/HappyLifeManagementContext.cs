using HappyLifeManagement.Data.Entity;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace HappyLifeManagement.Data
{
    public class HappyLifeManagementContext : DbContext
    {
        public HappyLifeManagementContext() : base("Name=HappyLifeManagementConnectionString")
        {
        }

        public DbSet<Note> Notes { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpenseCategory> ExpenseCategories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
