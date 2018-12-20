using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class EventSoc
    {
        public int Id { get; set; }
        public Society currentSoc { get; set; }
        public Evenement currentEvent { get; set; }
    }
}