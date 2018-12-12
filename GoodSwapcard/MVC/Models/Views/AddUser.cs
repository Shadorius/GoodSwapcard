using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models.Views
{
    public class AddUser
    {
        public Utilisateur Utilisateur { get; set; }
        public IEnumerable<Statut> Statuts { get; set; }
    }
}