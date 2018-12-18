using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelServer
{
    public class MessagerieMS
    {
        public int Id { get; set; }
        public int IdUserOne { get; set; }
        public int IdUserTwo { get; set; }
        public string Content { get; set; }
        public DateTime DateSend { get; set; }
    }
}
