using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cube.Models
{
    public class Role
    {
        public long Id { get; set; }
        public string NameRole { get; set; }
        public string ShortRole { get; set; }

        public virtual ICollection<UserRole> UserRole{ get; set; }
    }
}
