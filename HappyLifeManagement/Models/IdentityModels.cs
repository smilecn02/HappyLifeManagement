using HappyLifeManagement.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HappyLifeManagement.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("HappyLifeManagementConnectionString", throwIfV1Schema: false)
        {
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}