using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cube.Models
{
    public class EquipmentStatuse
    {

        public long Id { get; set; }
        public string EquipmentStatusName { get; set; }

        public virtual ICollection<Equipment> Equipment { get; set; }
    }
}
