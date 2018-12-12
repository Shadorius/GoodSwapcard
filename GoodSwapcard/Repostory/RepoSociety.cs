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
    public class RepoSociety : IRepository<SocietyMS, int>
    {
        private Connexion con = new Connexion();

        public bool Delete(int id)
        {
            string Query = "DELETE FROM [Society] WHERE [Id]=" + id;
            bool QueryState = con.Delete(Query);
            return QueryState;
        }

        public SocietyMS Get(int id)
        {
            string Query = "Select * from [Society] where [Id] =" + id;
            List<Dictionary<string, object>> Result = con.getData(Query);
            SocietyMS society = null;

            if (Result.Count != 0)
            {
                society = new SocietyMS
                {
                    Id = (int)Result[0]["Id"],
                    SocietyName = (string)Result[0]["SocietyName"],
                    SocietyDesc = (string)Result[0]["SocietyDesc"],
                    Phone = (string)Result[0]["Phone"],
                    IdLoc = (int)Result[0]["IdLoc"],
                    IdBoss = (int)Result[0]["IdBoss"]
                };
            }

            return society;
        }

        public List<SocietyMS> GetAll()
        {
            string Query = "Select * from [Society]";
            List<Dictionary<string, object>> Result = con.getData(Query);
            List<SocietyMS> CurrentList = new List<SocietyMS>();

            if (Result.Count != 0)
            {
                for (int i = 0; i < Result.Count; i++)
                {
                    SocietyMS society = new SocietyMS {
                        Id = (int)Result[i]["Id"],
                        SocietyName = (string)Result[i]["SocietyName"],
                        SocietyDesc = (string)Result[i]["SocietyDesc"],
                        Phone = (string)Result[i]["Phone"],
                        IdLoc = (int)Result[i]["IdLoc"],
                        IdBoss = (int)Result[i]["IdBoss"]
                    };
                    CurrentList.Add(society);
                }
            }
            return CurrentList;
        }

        public bool Insert(SocietyMS item)
        {
            string Query = "INSERT INTO [Society] Values (";
            Query += "'" + item.SocietyName + "'";
            Query += "'" + item.SocietyDesc + "'";
            Query += "'" + item.Phone + "'";
            Query += "'" + item.IdLoc + "'";
            Query += "'" + item.IdBoss + "')";

            bool QueryResult = con.Insert(Query);
            return QueryResult;
        }

        public bool Update(SocietyMS item)
        {
            string Query = "UPDATE [Society] SET";
            Query += "SocietyName = '" + item.SocietyName + "'";
            Query += "SocietyDesc = '" + item.SocietyDesc + "'";
            Query += "Phone = '" + item.Phone + "'";
            Query += "IdLoc = '" + item.IdLoc + "'";
            Query += "IdBoss = '" + item.IdBoss + "'";
            Query += " WHERE Id=" + item.Id;

            bool QueryResult = con.Insert(Query);

            return QueryResult;
        }
    }
}
