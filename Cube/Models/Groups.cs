using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cube.Models
{
    public class Groups
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long NameGroup { get; set; }


        public virtual ConnectionGroup ConnectionGroup { get; set; }
        public virtual ICollection<GroupOfChildren> GroupOfChildren { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<SelectGroup> SelectGroup { get; set; }
        public virtual ICollection<UserInEvent> UserInEvent { get; set; }
    }
}
