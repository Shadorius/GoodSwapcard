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
    public class RepoMessagerie : IRepository<MessagerieMS, int>
    {
        private Connexion _con = new Connexion();
        

        public MessagerieMS Get(int id)
        {
            string Query = "Select * from [Messagerie] where [Id] =" + id;
            List<Dictionary<string, object>> Result = _con.getData(Query);
            MessagerieMS CurrentMessagerie = null;

            if (Result.Count != 0)
            {
                CurrentMessagerie = new MessagerieMS
                {
                    Id = (int)Result[0]["Id"],
                    IdUserOne = (int)Result[0]["IdUserOne"],
                    IdUserTwo = (int)Result[0]["IdUserTwo"],
                    Content = (string)Result[0]["Content"]
                };
            }

            return CurrentMessagerie;
        }

        public List<MessagerieMS> GetAll()
        {
            string Query = "Select * from [Messagerie]";
            List<Dictionary<string, object>> Result = _con.getData(Query);
            List<MessagerieMS> CurrentList = new List<MessagerieMS>();
            if (Result.Count != 0)
            {
                for (int i = 0; i < Result.Count; i++)
                {
                    MessagerieMS temp = new MessagerieMS
                    {
                        Id = (int)Result[i]["Id"],
                        IdUserOne = (int)Result[i]["IdUserOne"],
                        IdUserTwo = (int)Result[i]["IdUserTwo"],
                        Content = (string)Result[i]["Content"]
                    };
                    CurrentList.Add(temp);
                }
            }
            return CurrentList;
        }

        public bool Insert(MessagerieMS item)
        {
            string Query = "INSERT INTO [Messagerie] Values(";
            Query += item.IdUserOne;
            Query += ","+item.IdUserTwo;
            Query += ",'"+item.Content+"'";
            Query += ")";

            bool QueryResult = _con.Insert(Query);
            return QueryResult;
        }

        public bool Update(MessagerieMS item)
        {
            string Query = "UPDATE [Messagerie] SET";
            Query += "IdUserOne = " + item.IdUserOne;
            Query += ", IdUserTwo = " + item.IdUserTwo;
            Query += ", Content = '" + item.Content+"'";
            Query += " WHERE Id=" + item.Id;

            bool QueryResult = _con.Insert(Query);
            return QueryResult;
        }

        public bool Delete(int id)
        {
            string Query = "Delete from [Messagerie] where [Id]=" + id;
            bool QueryState = _con.Delete(Query);
            return QueryState;
        }
    }
}
