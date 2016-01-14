using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Ingresso.Identity.Classes
{
    public class ApplicationUser : IdentityUser
    {
        public virtual string Name { get; set; }
        public virtual long DocumentNumber { get; set; }
        public virtual DateTime BirthDate { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual string AddressDescription { get; set; }
        public virtual string AddressNumber { get; set; }
        public virtual string AddressComplement { get; set; }
        public virtual string AddressZipCode { get; set; }
        public virtual string AddressNeighborhood { get; set; }
        public virtual string AddressCity { get; set; }
        public virtual string AddressState { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var ret = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            return ret;
        }
    }
}
