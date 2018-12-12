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
        private Connexion _con = new Connexion();

        public UtilisateurMS Get(int id)
        {
            List<Dictionary<string, Object>> list;
            UtilisateurMS uti = new UtilisateurMS();
            list = _con.getData("Select * from Utils where Id = " + id);

            uti.Id          =   (int)     list[0]["Id"];
            uti.LastName    =   (string)  list[0]["LastName"];
            uti.FirstName   =   (string)  list[0]["FirstName"];
            uti.PsW         =   (string)  list[0]["PsW"];
            uti.Email       =   (string)  list[0]["Email"];
            uti.Phone       =   list[0]["Phone"] == DBNull.Value ? null : (string)list[0]["Phone"];
            uti.Birthdate   =   list[0]["Birthdate"] == DBNull.Value ? null :(DateTime?)list[0]["Birthdate"];
            uti.Statut      =   (int)  list[0]["Statut"];
            return uti;
        }

        public List<UtilisateurMS> GetAll()
        {
            string Query = "Select * from Utils";
            List<Dictionary<string, object>> listResult = _con.getData(Query);
            List<UtilisateurMS> list = new List<UtilisateurMS>();

            if (listResult.Count != 0)
            {
                foreach (Dictionary<string, object> item in listResult)
                {
                    UtilisateurMS temp = new UtilisateurMS();

                    temp.Id         = (int)     item["Id"];
                    temp.LastName   = (string)  item["LastName"];
                    temp.FirstName  = (string)  item["FirstName"];
                    temp.PsW        = (string)  item["PsW"];
                    temp.Email      = (string)  item["Email"];

                    temp.Phone      = item["Phone"]     == DBNull.Value ? null : (string)   item["Phone"];
                    temp.Birthdate  = item["Birthdate"] == DBNull.Value ? null : (DateTime?)item["Birthdate"];
                    temp.Statut     = (int)item["IdStatut"];

                    list.Add(temp);
                }
            }
            return list;
        }

        public bool Insert(UtilisateurMS util)
        {
            string Query = "INSERT INTO [Utils] Values(";
            Query += "'" + util.LastName    + "', ";
            Query += "'" + util.FirstName   + "', ";
            Query += "'" + util.PsW         + "', ";
            Query += "'" + util.Email       + "', ";
            Query +=       util.Phone     == null ? "null,"     : "'" + util.Phone + "', ";
            Query +=       util.Birthdate == null ? "null,"     : "'" + util.Birthdate  + "',";
            Query +=       util.Statut      + ")";

            bool QueryResult = _con.Insert(Query);
            return QueryResult;
        }

        public bool Update(UtilisateurMS util)
        {
            string  Query = "UPDATE [Utils] SET ";

                    Query += "LastName  = '"    +   util.LastName     + "', ";
                    Query += "FirstName = '"    +   util.FirstName    + "', ";
                    Query += "PsW       = '"    +   util.PsW          + "', ";
                    Query += "Email     = '"    +   util.PsW          + "', ";

                    Query += ", Phone = ";
                    Query += util.Phone     == null ? "null" : "'" + util.Phone + "' ";
                    Query += ", Birthdate = ";
                    Query += util.Birthdate == null ? "null" : "'" + util.Birthdate + "' ";
                    Query += " WHERE Id = " + util.Id;

            bool QueryResult = _con.Insert(Query);

            return QueryResult;
        }

        public bool Delete(int id)
        {
            bool QueryResult = _con.Insert("delete from Utils where Id="+id);
            return QueryResult;
        }
    }
}
