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
            list = _con.getData("Select * from Utils where Id = @0", id);

            uti.Id          =   (int)     list[0]["Id"];
            uti.LastName    =   (string)  list[0]["LastName"];
            uti.FirstName   =   (string)  list[0]["FirstName"];
            uti.PsW         =   (string)  list[0]["PsW"];
            uti.Email       =   (string)  list[0]["Email"];
            uti.Phone       =   list[0]["Phone"] == DBNull.Value ? null : (string)list[0]["Phone"];
            uti.Birthdate   =   list[0]["Birthdate"] == DBNull.Value ? null :(DateTime?)list[0]["Birthdate"];
            uti.Statut      =   (int)  list[0]["IdStatut"];
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
            string optionnal = "";
            string optionnal2 = "";
            string optionnalParams = "";

            optionnal += (util.Phone == null ?"": ", Phone");
            optionnalParams += (string.IsNullOrEmpty(optionnal) ? "" : ", @5");
            optionnal2 += (util.Birthdate == null ? "" : ", Birthdate");
            optionnalParams += (string.IsNullOrEmpty(optionnal2) ? "" : ", @6");

            string query = "INSERT INTO [Utils](LastName,FirstName,PsW, Email, IdStatut" + optionnal + ") values(@0, @1, @2, @3, @4" + optionnalParams + ")";


            bool QueryResult = _con.Insert(query, util.LastName, util.FirstName, util.PsW, util.Email, util.Statut, util.Phone, util.Birthdate);
            return QueryResult;
        }

        public bool Update(UtilisateurMS util)
        {
            string query = "UPDATE [Utils] SET LastName = @1, FirstName = @2, Psw = @3, Email = @4, IdStatut = @5";
            query += util.Phone == null ? "" : ", Phone = @6";
            query += util.Birthdate == null ? "" : ", Birthdate = @7";
            query += " Where Id = @0";

            bool QueryResult = _con.Update(query, util.Id, util.LastName, util.FirstName, util.PsW, util.Email, util.Statut, util.Phone, util.Birthdate);

            return QueryResult;
        }

        public bool Delete(int id)
        {
            bool QueryResult = _con.Delete("delete from Utils where Id=@0",id);
            return QueryResult;
        }
    }
}
