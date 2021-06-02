using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cube.Models
{
    public class EquipmentGroupType
    {
        public long Id { get; set; }
        public string EquipmentGroupTypeName { get; set; }

        public virtual ICollection<EquipmentGroup> EquipmentGroup { get; set; }
    }
}
