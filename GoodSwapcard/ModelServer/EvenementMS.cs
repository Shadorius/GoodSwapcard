﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelServer
{
    public class EvenementMS
    {
        public int Id { get; set; }
        public string EvenementName { get; set; }
        public string EventDesc { get; set; }
        public DateTime? DateEvent { get; set; }
        public int IdUserCreator { get; set; }
        public int IdPlace { get; set; }
    }
}
