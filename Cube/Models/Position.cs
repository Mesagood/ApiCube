using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cube.Models
{
    public class Position
    {  
        public long Id { get; set; }
        public string NamePosition { get; set; }
        public string CodePosition { get; set; }

        public virtual ICollection<UserPost> UserPost { get; set; }


    }
}
