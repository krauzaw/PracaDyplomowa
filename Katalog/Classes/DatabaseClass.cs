using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katalog.Classes
{
    public class DatabaseClass
    {
        public string IDProduct { get; set; }
        public string Name { get; set; }
        public int ValueInDatabase { get; set; }
        public string Unit { get; set; }
        public Subproduct[] Subprod { get; set; }
        public Dictionary<string, string> Details { get; set; }          
    }
}
