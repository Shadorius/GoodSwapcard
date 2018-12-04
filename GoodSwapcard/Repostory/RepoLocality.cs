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
    public class RepoLocality : IRepository<LocalityMS, int>
    {
        private Connexion _con = new Connexion();
        public bool Delete(int id)
        {
            string Query = "Delete from [Locality] where [Id]=" + id;
            bool QueryState = _con.Delete(Query);
            return QueryState;
        }

        public LocalityMS Get(int id)
        {
            string Query = "Select * from [Locality] where [Id] =" + id;
            List<Dictionary<string, object>> Result = _con.getData(Query);
            LocalityMS CurrentLocality = null;

            if (Result.Count != 0)
            {
                CurrentLocality = new LocalityMS
                {
                    Id = (int)Result[0]["Id"],
                    LocalityName = (string)Result[0]["LocalityName"],
                    CP = (string)Result[0]["CP"],
                    IdCountry = (int)Result[0]["IdCountry"]
                };
            }
            return CurrentLocality;
        }

        public List<LocalityMS> GetAll()
        {
            string Query = "Select * from [Country]";
            List<Dictionary<string, object>> Result = _con.getData(Query);
            List<LocalityMS> CurrentList = new List<LocalityMS>();
            if (Result.Count != 0)
            {
                for (int i = 0; i < Result.Count; i++)
                {
                    LocalityMS temp = new LocalityMS
                    {
                        Id = (int)Result[0]["Id"],
                        LocalityName = (string)Result[0]["LocalityName"],
                        CP = (string)Result[0]["CP"],
                        IdCountry = (int)Result[0]["IdCountry"]
                    };
                    CurrentList.Add(temp);
                }
            }
            return CurrentList;
        }

        public bool Insert(LocalityMS item)
        {
            string Query = "INSERT INTO [Country] Values (";
            Query += "'" + item.LocalityName + "'";
            Query += ", '" + item.CP + "'";
            Query += "," + item.IdCountry;
            Query += ")";

            bool QueryResult = _con.Insert(Query);
            return QueryResult;
        }

        public bool Update(LocalityMS item)
        {
            string Query = "UPDATE [Country] SET";
            Query += "LocalityName = '" + item.LocalityName + "'";
            Query += ", CP = '" + item.CP + "'";
            Query += ", IdCountry = " + item.IdCountry + "";
            Query += " WHERE Id=" + item.Id;

            bool QueryResult = _con.Insert(Query);
            return QueryResult;
        }
    }
}
