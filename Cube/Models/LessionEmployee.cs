using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cube.Models
{
    public class LessionEmployee
    {
        public long Id { get; set; }
        public long LessionId { get; set; }
        public long EmployeeId{ get; set; }

        public virtual Lession Lession { get; set; }
        public virtual User User { get; set; }
    }
}
