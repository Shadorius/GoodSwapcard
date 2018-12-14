using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelServer
{
    public class SocietyMS
    {
        public int Id { get; set; }
        public string SocietyName { get; set; }
        public string SocietyDesc { get; set; }
        public string SocietyTinyDesc { get; set; }
        public string Img { get; set; }
        public string WebSite { get; set; }
        public string Phone { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public int IdLoc { get; set; }
        public int IdBoss { get; set; }
    }
}
