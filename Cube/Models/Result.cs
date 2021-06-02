using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cube.Models
{
    public class Result
    {
        public long Id { get; set; }
        public double Procent { get; set; }

        public virtual ICollection<TestQuest> TestQuest { get; set; }
    }
}
