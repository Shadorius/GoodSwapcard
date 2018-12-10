using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelServer
{

    //table Utils
    public class UtilisateurMS
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string PsW { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime? Birthdate { get; set; }
        public StatutMS Statut { get; set; }
    }
}
