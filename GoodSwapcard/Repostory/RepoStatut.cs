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
    public class RepoStatut : IRepository<StatutMS, int>
    {
        Connexion _con = new Connexion();
        public bool Delete(int id)
        {
            string Query = "Delete from [Statut] where [Id]= @0";
            bool QueryState = _con.Delete(Query, id);
            return QueryState;
        }

        public StatutMS Get(int id)
        {
            string Query = "Select * from [Statut] where [Id] = @0";
            List<Dictionary<string, object>> Result = _con.getData(Query, id);
            StatutMS CurrentStatut = null;

            if (Result.Count != 0)
            {
                CurrentStatut = new StatutMS
                {
                    Id = (int)Result[0]["Id"],
                    StatutName = (string)Result[0]["StatutName"]
                };
            }

            return CurrentStatut;
        }

        public List<StatutMS> GetAll()
        {
            string Query = "Select * from [Statut]";
            List<Dictionary<string, object>> Result = _con.getData(Query);
            List<StatutMS> CurrentList = new List<StatutMS>();
            if (Result.Count != 0)
            {
                for (int i = 0; i < Result.Count; i++)
                {
                    StatutMS temp = new StatutMS
                    {
                        Id = (int)Result[i]["Id"],
                        StatutName = (string)Result[i]["StatutName"]
                    };
                    CurrentList.Add(temp);
                }
            }
            return CurrentList;
        }

        public bool Insert(StatutMS item)
        {
            string Query = "INSERT INTO [Statut] Values(@0)";

            bool QueryResult = _con.Insert(Query, item.StatutName);
            return QueryResult;
        }

        public bool Update(StatutMS item)
        {
            string Query = "UPDATE [Statut] SET";
            Query += "StatutName = @1";
            Query += " WHERE Id= @0";

            bool QueryResult = _con.Insert(Query, item.Id, item.StatutName);
            return QueryResult;
        }
    }
}
