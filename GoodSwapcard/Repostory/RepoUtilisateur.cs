using DAL;
using ModelServer;
using Repostory.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repostory
{
    public class RepoUtilisateur : IRepository<UtilisateurMS, int>
    {
        Connexion con = new Connexion();

        public UtilisateurMS Get(int id)
        {
            List<Dictionary<string, Object>> list;
            UtilisateurMS uti = new UtilisateurMS();
            list = con.getData("Select * from Utils where Id = " + id);

            uti.Id          =   (int)     list[0]["Id"];
            uti.LastName    =   (string)  list[0]["LastName"];
            uti.FirstName   =   (string)  list[0]["FirstName"];
            uti.PsW         =   (string)  list[0]["PsW"];
            uti.Email       =   (string)  list[0]["Email"];
            //uti.Phone       =   (string)  list[0]["Phone"];
            //uti.Birthdate   =   (DateTime)list[0]["Birthdate"];

            return uti;
        }

        public List<UtilisateurMS> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Insert(UtilisateurMS item)
        {
            throw new NotImplementedException();
        }

        public bool Update(UtilisateurMS item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
