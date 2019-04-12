using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Poi
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Race> Races { get; set; }
    }
}
