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
            string Query = "Delete from [RDV] where [Id]=" + id;
            bool QueryState = _con.Delete(Query);
            return QueryState;
        }

        public RdVMS Get(int id)
        {
            string Query = "Select * from [RDV] where [Id] =" + id;
            List<Dictionary<string, object>> Result = _con.getData(Query);
            RdVMS CurrentRDV = null;

            if (Result.Count != 0)
            {
                CurrentRDV = new RdVMS
                {
                    Id = (int)Result[0]["Id"],
                    IdHour = (int)Result[0]["IdHour"],
                    IdCandidat = (int)Result[0]["IdCandidat"],
                    IdRep = (int)Result[0]["IdRep"]
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
                        IdRep = (int)Result[i]["IdRep"]
                    };
                    CurrentList.Add(temp);
                }
            }
            return CurrentList;
        }

        public bool Insert(RdVMS item)
        {
            string Query = "INSERT INTO [RDV] Values (";
            Query += "" + item.IdHour + ",";
            Query += "," + item.IdCandidat;
            Query += "," + item.IdRep;
            Query += ")";

            bool QueryResult = _con.Insert(Query);
            return QueryResult;
        }

        public bool Update(RdVMS item)
        {
            string Query = "UPDATE [RDV] SET";
            Query += "IdHour = " + item.IdHour + "";
            Query += ", IdCandidat = " + item.IdCandidat + "";
            Query += ", IdRep = " + item.IdRep + "";
            Query += " WHERE Id=" + item.Id;

            bool QueryResult = _con.Insert(Query);
            return QueryResult;
        }
    }
}
