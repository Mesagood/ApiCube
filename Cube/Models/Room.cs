using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cube.Models
{
    public class Room
    {
        public long Id { get; set; }
        public long? RoomNumber { get; set; }
        public string RoomName { get; set; }
        public long EmployeeResponsibleForRoomId { get; set; }
        public string RoomDeleted { get; set; }

        public virtual ICollection<Equipment> Equipment { get; set; }
        public virtual User User { get; set; }
    }
}
