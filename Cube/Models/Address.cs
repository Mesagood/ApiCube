using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cube.Models
{
    public class Address
    {
        public long Id { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public long NumberHouse { get; set; }
        public long NumberApartament { get; set; }

       
        public virtual ICollection<User> User { get; set; }
    }
}
