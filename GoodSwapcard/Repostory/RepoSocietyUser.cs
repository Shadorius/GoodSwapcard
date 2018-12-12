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
    public class RepoSocietyUser : IRepository<SocietyUserMS, int>
    {
        private Connexion con = new Connexion();

        public bool Delete(int id)
        {
            string Query = "DELETE FROM [SocietyUser] WHERE [Id]=" + id;
            bool QueryState = con.Delete(Query);
            return QueryState;
        }

        public SocietyUserMS Get(int id)
        {
            string Query = "Select * from [Society] where [Id] =" + id;
            List<Dictionary<string, object>> Result = con.getData(Query);
            SocietyUserMS societyUser = null;

            if (Result.Count != 0)
            {
                societyUser = new SocietyUserMS
                {
                    Id = (int)Result[0]["Id"],
                    IdUser = (int)Result[0]["IdUser"],
                    IdSociety = (int)Result[0]["IdSociety"]                    
                };
            }

            return societyUser;
        }

        public List<SocietyUserMS> GetAll()
        {
            string Query = "Select * from [SocietyUser]";
            List<Dictionary<string, object>> Result = con.getData(Query);
            List<SocietyUserMS> CurrentList = new List<SocietyUserMS>();

            if (Result.Count != 0)
            {
                for (int i = 0; i < Result.Count; i++)
                {
                    SocietyUserMS societyUser = new SocietyUserMS
                    {
                        Id = (int)Result[i]["Id"],
                        IdUser = (int)Result[i]["IdUser"],
                        IdSociety = (int)Result[i]["IdSociety"]
                    };
                    CurrentList.Add(societyUser);
                }
            }
            return CurrentList;
        }

        public bool Insert(SocietyUserMS item)
        {
            string Query = "INSERT INTO [SocietyUser] Values (";
            Query += " " + item.IdUser + ",";
            Query += " " + item.IdSociety + ")";

            bool QueryResult = con.Insert(Query);
            return QueryResult;
        }

        public bool Update(SocietyUserMS item)
        {
            string Query = "UPDATE [SocietyUser] SET";
            Query += "IdUser = " + item.IdUser + ",";
            Query += "IdSociety = " + item.IdSociety + " ";
            Query += "WHERE Id=" + item.Id;

            bool QueryResult = con.Insert(Query);

            return QueryResult;
        }
    }
}
