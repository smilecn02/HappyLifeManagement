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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
