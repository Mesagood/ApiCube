using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cube.Models
{
    public class StaffEvent
    {
        public long Id { get; set; }
        public long UeId { get; set; }
        public long UserId { get; set; }
        public long Help { get; set; }

        public virtual UserInEvent UserInEvent { get; set; }
        public virtual User User { get; set; }
    }
}
