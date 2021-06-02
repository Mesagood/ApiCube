using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cube.Models
{
    public class EquipmentGroup
    {
        public long Id { get; set; }
        public string EquipmentGroupName { get; set; }
        public long EquipmentGroupTypeId { get; set; }
        public string EquipmentGroupDescription { get; set; }
        public string EquipmentGroupDeleted { get; set; }

        public virtual EquipmentGroupType EquipmentGroupType { get; set; }      
        public virtual ICollection<Equipment> Equipment { get; set; }
    }
}
