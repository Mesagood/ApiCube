using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cube.Models
{
    public class ServiceNote
    {
        public long Id { get; set; }
        public string ServiceNoteNumber { get; set; }
        public long EmployeeResponsibleForServiceNoteId { get; set; }
        public DateTime? WritingDate { get; set; }
        public string ServiceNoteDeleted { get; set; }

        public virtual ICollection<EquipmentsInServiceNote> EquipmentsInServiceNote { get; set; }
        public virtual User User { get; set; }
    }
}
