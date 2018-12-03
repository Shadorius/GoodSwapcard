using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelServer
{
    public class PlaceMS
    {
        public int Id { get; set; }
        public string PlaceName { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public int IdLoc { get; set; }
    }
}
