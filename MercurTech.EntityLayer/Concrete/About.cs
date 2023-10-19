using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercurTech.EntityLayer.Concrete
{
    public class About
    {
        public int AboutID { get; set; }
        public string Photopath { get; set; }

        public string Description { get; set; }

        public string Mission { get; set; }

        public string Vision { get; set; }

        public string Target { get; set; }
    }
}
