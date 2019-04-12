using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
   public class DisplayConfiguration
    {

        public int Id { get; set; }

        public string DeviceName { get; set; }

        public bool SpeedAvg { get; set; }

        public bool SpeedMax { get; set; }

        public ApplicationIdentity applicationIdentity;

        public UniteDistance uniteDistance ;

        public DisplayConfiguration()
        {

        }
    }
}
