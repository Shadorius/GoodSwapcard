using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models.Views
{
    public class ListEventSocietyUser
    {
        public Society SocietyEvent { get; set; }
        public IEnumerable<Utilisateur> UtilEvent { get; set; }
    }
}