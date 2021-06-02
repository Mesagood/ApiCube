using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cube.Models
{
    public class Passport
    {
        public long Id{ get; set; }
        public string Series { get; set; }
        public string Number { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}
