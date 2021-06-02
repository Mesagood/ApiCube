using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cube.Models
{
    public class Statuse
    {
        public long Id { get; set; }
        public string NameStatus { get; set; }

        public virtual ICollection<UserInEvent> UserInEvent { get; set; }
    }
}
