using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cube.Models
{
    public class EquipmentsInServiceNote
    {
        public long Id { get; set; }
        public long EquipmentId { get; set; }
        public long ServiceNoteId { get; set; }
        public string EquipmentInServiceNoteDeleted { get; set; }

        public virtual Equipment Equipment { get; set; }
        public virtual ServiceNote ServiceNote { get; set; }
    }
}
