using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cube.Models
{
    public class UserInEvent
    {
        public long Id { get; set; }
        public long EventId{ get; set; }
        public long UserId { get; set; }
        public long GroupId { get; set; }
        public long StatusId { get; set; }
        public string Comment { get; set; }
        public string Info { get; set; }
        public string Certificate{ get; set; }

        public virtual Event Event { get; set; }
        public virtual Groups Groups { get; set; }
        public virtual ICollection<StaffEvent> StaffEvent{ get; set; }
        public virtual Statuse Statuse { get; set; }
        public virtual User User { get; set; }
    }
}
