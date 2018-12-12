using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelClient
{
    public class SocietyMC
    {
        public int Id { get; set; }
        public string SocietyName { get; set; }
        public string SocietyDesc { get; set; }
        public string Phone { get; set; }
        public int IdLoc { get; set; }
        public int IdBoss { get; set; }
    }
}
