using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models.Views
{
    public class EditUser
    {
        public UtilisateurForEdit Utilisateur { get; set; }
        public IEnumerable<Statut> Statuts { get; set; }
    }
}