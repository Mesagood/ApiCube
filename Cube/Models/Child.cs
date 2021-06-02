using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cube.Models
{
    public class Child
    {
        public long Id { get; set; }
        public string FirstNameChild{ get; set; }
        public string LastNameChild { get; set; }
        public string MiddleNameChild { get; set; }
        public DateTime DateOfBirdh{ get; set; }
        public string FirstNameParent{ get; set; }
        public string LastNameParent { get; set; }
        public string MiddleNameParent { get; set; }
        public string TelephoneParent{ get; set; }
        public string SNILS { get; set; }
        public long PFDO { get; set; }
        public string Program { get; set; }
        public int ClassScool{ get; set; }
        public int Shift { get; set; }
        public string School { get; set; }
        public string Address { get; set; }
        public int Educator { get; set; }
        public string Status { get; set; }
        public string StatusGroup { get; set; }

        public virtual User User { get; set; }


        public virtual ICollection<GroupOfChildren> GroupOfChildren { get; set; }
        public virtual ICollection<GroupChild> GroupChild { get; set; }
        public virtual ICollection<SelectGroup> SelectGroup { get; set; }
    }
    
}
