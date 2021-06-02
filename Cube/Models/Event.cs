using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cube.Models
{
    public class Event
    {
        public long Id { get; set; }
        public string nameEvent{ get; set; }
        public DateTime DateEvent { get; set; }
        public long LevelId{ get; set; }
        public string LinkEvent{ get; set; }
        public long FromOne { get; set; }


        public virtual Level Levels { get; set; } 
        public virtual ICollection<UserInEvent> UserInEvent { get; set; }
    }
}
