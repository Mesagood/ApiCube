using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cube.Models
{
    public class EquipmentMovementHistory
    {
        public long Id { get; set; }
        public long EquipmentId { get; set; }
        public string PlaceOfMovement { get; set; }
        public long? EmployeeResponsibleForMovingId { get; set; }
        public DateTime? DateOfMovement { get; set; }

        public virtual User User { get; set; }
        public virtual Equipment Equipment { get; set; }

    }
}
