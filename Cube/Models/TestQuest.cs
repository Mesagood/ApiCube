using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cube.Models
{
    public class TestQuest
    {
        public long Id{ get; set; }
        public long TestId{ get; set; }
        public long ModuleTestId{ get; set; }
        public long QuesAnswId{ get; set; }
        public long ResultId { get; set; }
        public long CinId { get; set; }

        public virtual CinChild CinChild { get; set; }
        public virtual ModuleTest ModuleTest { get; set; }
        public virtual QuestionAnswer QuestionAnswer { get; set; }
        public virtual Result Result { get; set; }
        public virtual Test Test { get; set; }

    }
}
