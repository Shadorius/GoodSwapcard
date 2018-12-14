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
                    SocietyTinyDesc = (string)Result[0]["SocietyTinyDesc"],
                    Img = (string)Result[0]["Img"],
                    WebSite = (string)Result[0]["WebSite"],
                    Phone = (string)Result[0]["Phone"],
                    Street = (string)Result[0]["Street"],
                    Number = (string)Result[0]["Number"],
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
                        SocietyTinyDesc = (string)Result[i]["SocietyTinyDesc"],
                        Img = (string)Result[i]["Img"],
                        WebSite = (string)Result[i]["WebSite"],
                        Phone = (string)Result[i]["Phone"],
                        Street = (string)Result[i]["Street"],
                        Number = (string)Result[i]["Number"],
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
            Query += "'" + item.SocietyName + "',";
            Query += "'" + item.SocietyDesc + "',";
            Query += "'" + item.SocietyTinyDesc + "',";
            Query += "'" + item.Img + "',";
            Query += "'" + item.WebSite + "',";
            Query += "'" + item.Phone + "',";
            Query += "'" + item.Street + "',";
            Query += "'" + item.Number + "',";
            Query += " " + item.IdLoc + ",";
            Query += " " + item.IdBoss + ")";

            bool QueryResult = con.Insert(Query);
            return QueryResult;
        }

        public bool Update(SocietyMS item)
        {
            string Query = "UPDATE [Society] SET";
            Query += "SocietyName = '" + item.SocietyName + "',";
            Query += "SocietyDesc = '" + item.SocietyDesc + "',";
            Query += "SocietyTinyDesc = '" + item.SocietyTinyDesc + "',";
            Query += "Img = '" + item.Img + "',";
            Query += "WebSite = '" + item.WebSite + "',";
            Query += "Phone = '" + item.Phone + "',";
            Query += "Street = '" + item.Street + "',";
            Query += "Number = '" + item.Number + "',";
            Query += "IdLoc = " + item.IdLoc + ",";
            Query += "IdBoss = " + item.IdBoss + " ";
            Query += "WHERE Id=" + item.Id;

            bool QueryResult = con.Insert(Query);

            return QueryResult;
        }
    }
}
