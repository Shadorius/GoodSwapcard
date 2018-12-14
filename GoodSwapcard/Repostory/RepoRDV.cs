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
    public class RepoRDV : IRepository<RdVMS, int>
    {
        private Connexion _con = new Connexion();
        public bool Delete(int id)
        {
            string Query = "Delete from [RDV] where [Id]= @0";
            bool QueryState = _con.Delete(Query, id);
            return QueryState;
        }

        public RdVMS Get(int id)
        {
            string Query = "Select * from [RDV] where [Id] = @0";
            List<Dictionary<string, object>> Result = _con.getData(Query, id);
            RdVMS CurrentRDV = null;

            if (Result.Count != 0)
            {
                CurrentRDV = new RdVMS
                {
                    Id = (int)Result[0]["Id"],
                    IdHour = (int)Result[0]["IdHour"],
                    IdCandidat = (int)Result[0]["IdCandidat"],
                    IdRep = (int)Result[0]["IdRep"],
                    RdvState = (bool)Result[0]["RdvState"]
                };
            }
            return CurrentRDV;
        }

        public List<RdVMS> GetAll()
        {
            string Query = "Select * from [RDV]";
            List<Dictionary<string, object>> Result = _con.getData(Query);
            List<RdVMS> CurrentList = new List<RdVMS>();
            if (Result.Count != 0)
            {
                for (int i = 0; i < Result.Count; i++)
                {
                    RdVMS temp = new RdVMS
                    {
                        Id = (int)Result[i]["Id"],
                        IdHour = (int)Result[i]["IdHour"],
                        IdCandidat = (int)Result[i]["IdCandidat"],
                        IdRep = (int)Result[i]["IdRep"],
                        RdvState = (bool)Result[i]["RdvState"]
                    };
                    CurrentList.Add(temp);
                }
            }
            return CurrentList;
        }

        public bool Insert(RdVMS item)
        {
            string Query = "INSERT INTO [RDV] Values (@0, @1, @2, @3)";

            bool QueryResult = _con.Insert(Query, item.IdHour, item.IdCandidat, item.IdRep, item.RdvState);
            return QueryResult;
        }

        public bool Update(RdVMS item)
        {
            string Query = "UPDATE [RDV] SET ";
            Query += "IdHour = @1";
            Query += ", IdCandidat = @2";
            Query += ", IdRep = @3, ";
            Query += "RdvState = @4";
            Query += " WHERE Id= @0";

            bool QueryResult = _con.Update(Query, item.Id, item.IdHour, item.IdCandidat, item.IdRep, item.RdvState);
            return QueryResult;
        }
    }
}
