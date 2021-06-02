using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cube.Models
{
    public class User
    {
        public long Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public DateTime BirthDay { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Photo { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public long GenderId { get; set; }
        public long PassportId { get; set; }
        public long AddressId { get; set; }

        public virtual Gender Gender { get; set; }
        public virtual Passport Passport { get; set; }
        public virtual Address Address { get; set; }

        public virtual ICollection<Child> Child { get; set; }         
        public virtual ICollection<EquipmentMovementHistory> EquipmentMovementHistory { get; set; }        
        public virtual ICollection<Groups> Groups { get; set; }         
        public virtual ICollection<LessionEmployee> LessionEmployees{ get; set; }         
        public virtual ICollection<ModuleChild> ModuleChild { get; set; }             
        public virtual ICollection<Room> Room { get; set; }         
        public virtual ICollection<ServiceNote> ServiceNote { get; set; }         
        public virtual ICollection<StaffEvent> StaffEvent { get; set; }         
        public virtual ICollection<UserInEvent> UserInEvent{ get; set; }         
        public virtual ICollection<UserPost> UserPosts{ get; set; }         
        public virtual ICollection<UserRole> UserRole { get; set; }

    }
}
