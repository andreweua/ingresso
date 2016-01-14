using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Ingresso.Identity.Classes
{
    public class IdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ApplicationUserConfig());

            base.OnModelCreating(modelBuilder);
        }

        public IdentityDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
    }
}
