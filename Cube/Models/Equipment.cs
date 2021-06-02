using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cube.Models
{
    public class Equipment
    {
        public long Id { get; set; }
        public long EquipmentStatusId { get; set; }
        public long EquipmentTypeId { get; set; }
        public long RoomId { get; set; }
        public string EquipmentInventoryNumber  { get; set; }
        public long EquipmentGroupId { get; set; }
        public DateTime? ContainmentDate { get; set; }
        public string EquipmentDeleted { get; set; }

        public virtual EquipmentGroup EquipmentGroup { get; set; }      
        public virtual ICollection<EquipmentMovementHistory> EquipmentMovementHistory { get; set; }
        public virtual EquipmentStatuse EquipmentStatuse { get; set; }
        public virtual EquipmentType EquipmentType { get; set; }       
        public virtual ICollection<EquipmentsInServiceNote> EquipmentsInServiceNote { get; set; }
        public virtual Room Room { get; set; }
    }
}
