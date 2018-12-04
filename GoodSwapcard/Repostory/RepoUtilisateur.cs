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
            //BirthDate = Result[i]["BirthDate"] == DBNull.Value ? null : (DateTime?)Result[i]["BirthDate"]

            return uti;
        }

        public List<UtilisateurMS> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Insert(UtilisateurMS item)
        {
            throw new NotImplementedException();
            //string Query = "INSERT INTO [User] Values(";
            //Query += "'" + item.Pseudo + "', ";
            //Query += "'" + item.Email + "', ";
            //Query += "'" + item.Password + "', ";
            //Query += item.Name == null ? "null, " : "'" + item.Name + "', ";
            //Query += item.LastName == null ? "null, " : "'" + item.LastName + "', ";
            //Query += item.Active == true ? "1, " : "0, ";
            //Query += item.BirthDate == null ? "null)" : "'" + item.BirthDate + "')";
        }

        public bool Update(UtilisateurMS item)
        {
            //string Query = "UPDATE [User] SET ";
            //Query += "Pseudo = '" + item.Pseudo + "', ";
            //Query += "Email = '" + item.Email + "', ";
            //Query += "Password = '" + item.Password + "', ";
            //Query += "Name = ";
            //Query += item.Name == null ? "null" : "'" + item.Name + "'";
            //Query += ", LastName = ";
            //Query += item.LastName == null ? "null" : "'" + item.LastName + "' ";
            //Query += ", BirthDate = ";
            //Query += item.BirthDate == null ? "null" : "'" + item.BirthDate + "' ";
            //Query += " WHERE UserId = " + item.UserId;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
