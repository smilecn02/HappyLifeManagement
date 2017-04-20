using HappyLifeManagement.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace HappyLifeManagement.Data
{
    public class HappyLifeManagementContext : IdentityDbContext<ApplicationUser>
    {
        public HappyLifeManagementContext() : base("HappyLifeManagementConnectionString", throwIfV1Schema: false)
        {
        }

        public static HappyLifeManagementContext Create()
        {
            return new HappyLifeManagementContext();
        }

        public DbSet<Note> Notes { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpenseCategory> ExpenseCategories { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        //}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
