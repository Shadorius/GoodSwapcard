using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelClient
{
    public class EvenementMC
    {
        public int Id { get; set; }
        public string EvenementName { get; set; }
        public DateTime? DateEvent { get; set; }
        public int IdUserCreator { get; set; }
        public int IdPlace { get; set; }
    }
}
