using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models.Views
{
    public class AddSociety
    {
        public Society addSociety { get; set; }
        public IEnumerable<Locality> Localities { get; set; }
    }
}