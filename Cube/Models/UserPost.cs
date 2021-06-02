using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cube.Models
{
    public class UserPost
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long PostId { get; set; }

        public virtual Position Position { get; set; }
        public virtual User User { get; set; }
    }
}
