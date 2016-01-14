using Ingresso.Identity.Classes;
using System;

namespace Ingresso.Data.Classes
{
    public class User
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public virtual string Id { get; set; }
        public virtual string Email { get; set; }
        public virtual bool EmailConfirmed { get; set; }
        public virtual string PasswordHash { get; set; }
        public virtual string SecurityStamp { get; set; }
        public virtual string PhoneNumber { get; set; }
        public virtual bool PhoneNumberConfirmed { get; set; }
        public virtual bool TwoFactorEnabled { get; set; }
        public virtual DateTime? LockoutEndDateUtc { get; set; }
        public virtual bool LockoutEnabled { get; set; }
        public virtual int AccessFailedCount { get; set; }
        public virtual string UserName { get; set; }

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
    }
}
