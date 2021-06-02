using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cube.Models
{
    public class Gender
    {
        public long Id { get; set; }
        public string NameGender { get; set; }
        public string ShortGender { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}
