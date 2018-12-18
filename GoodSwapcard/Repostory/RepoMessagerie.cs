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
    public class RepoMessagerie
    {
        private Connexion _con = new Connexion();
        

        public MessagerieMS Get(int id)
        {
            string Query = "Select * from [Messagerie] where [Id] = @0";
            List<Dictionary<string, object>> Result = _con.getData(Query, id);
            MessagerieMS CurrentMessagerie = null;

            if (Result.Count != 0)
            {
                CurrentMessagerie = new MessagerieMS
                {
                    Id = (int)Result[0]["Id"],
                    IdUserOne = (int)Result[0]["IdUserOne"],
                    IdUserTwo = (int)Result[0]["IdUserTwo"],
                    Content = (string)Result[0]["Content"],
                    DateSend = (DateTime)Result[0]["DateSend"]
                };
            }

            return CurrentMessagerie;
        }

        public List<MessagerieMS> GetAll(int id)
        {
            string Query = "Select * from [Messagerie] Where [IdUserOne] = @0 OR [IdUserTwo] = @0";
            List<Dictionary<string, object>> Result = _con.getData(Query, id);
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
                        Content = (string)Result[i]["Content"],
                        DateSend = (DateTime)Result[i]["DateSend"]
                    };
                    CurrentList.Add(temp);
                }
            }
            return CurrentList;
        }

        public bool Insert(MessagerieMS item)
        {
            string Query = "INSERT INTO [Messagerie] Values(@0,@1,@2)";

            bool QueryResult = _con.Insert(Query, item.IdUserOne, item.IdUserTwo, item.Content);
            return QueryResult;
        }

        public bool Update(MessagerieMS item)
        {
            string Query = "UPDATE [Messagerie] SET";
            Query += " IdUserOne = @1";
            Query += ", IdUserTwo = @2";
            Query += ", Content = @3";
            Query += " WHERE Id= @0";

            bool QueryResult = _con.Update(Query, item.Id, item.IdUserOne, item.IdUserTwo, item.Content);
            return QueryResult;
        }

        public bool Delete(int id)
        {
            string Query = "Delete from [Messagerie] where [Id]= @0";
            bool QueryState = _con.Delete(Query, id);
            return QueryState;
        }
    }
}
