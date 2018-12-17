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
    public class RepoStatutEvent : IRepository<StatutEventMS, int>
    {
        Connexion _con = new Connexion();
        public bool Delete(int id)
        {
            string Query = "Delete from [StatutEvent] where [Id]= @0";
            bool QueryState = _con.Delete(Query, id);
            return QueryState;
        }

        public StatutEventMS Get(int id)
        {
            string Query = "Select * from [StatutEvent] where [Id] = @0";
            List<Dictionary<string, object>> Result = _con.getData(Query, id);
            StatutEventMS CurrentStatut = null;

            if (Result.Count != 0)
            {
                CurrentStatut = new StatutEventMS
                {
                    Id = (int)Result[0]["Id"],
                    StatutEventName = (string)Result[0]["StatutEventName"]
                };
            }

            return CurrentStatut;
        }

        public List<StatutEventMS> GetAll()
        {
            string Query = "Select * from [StatutEvent]";
            List<Dictionary<string, object>> Result = _con.getData(Query);
            List<StatutEventMS> CurrentList = new List<StatutEventMS>();
            if (Result.Count != 0)
            {
                for (int i = 0; i < Result.Count; i++)
                {
                    StatutEventMS temp = new StatutEventMS
                    {
                        Id = (int)Result[i]["Id"],
                        StatutEventName = (string)Result[i]["StatutEventName"]
                    };
                    CurrentList.Add(temp);
                }
            }
            return CurrentList;
        }

        public bool Insert(StatutEventMS item)
        {
            string Query = "INSERT INTO [StatutEvent] Values(@0)";

            bool QueryResult = _con.Insert(Query, item.StatutEventName);
            return QueryResult;
        }

        public bool Update(StatutEventMS item)
        {
            string Query = "UPDATE [StatutEvent] SET ";
            Query += "StatutEventName = @1";
            Query += " WHERE Id= @0";

            bool QueryResult = _con.Update(Query, item.Id, item.StatutEventName);
            return QueryResult;
        }
    }
}
