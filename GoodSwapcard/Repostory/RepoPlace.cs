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
    public class RepoPlace : IRepository<PlaceMS, int>
    {
        private Connexion _con = new Connexion();
        public bool Delete(int id)
        {
            string Query = "Delete from [Place] where [Id]=" + id;
            bool QueryState = _con.Delete(Query);
            return QueryState;
        }

        public PlaceMS Get(int id)
        {
            string Query = "Select * from [Place] where [Id] =" + id;
            List<Dictionary<string, object>> Result = _con.getData(Query);
            PlaceMS CurrentPlace = null;

            if (Result.Count != 0)
            {
                CurrentPlace = new PlaceMS
                {
                    Id = (int)Result[0]["Id"],
                    PlaceName = (string)Result[0]["PlaceName"],
                    Street = (string)Result[0]["Street"],
                    Number = (string)Result[0]["Number"],
                    IdLoc = (int)Result[0]["IdLoc"]
                };
            }
            return CurrentPlace;
        }

        public List<PlaceMS> GetAll()
        {
            string Query = "Select * from [Place]";
            List<Dictionary<string, object>> Result = _con.getData(Query);
            List<PlaceMS> CurrentList = new List<PlaceMS>();
            if (Result.Count != 0)
            {
                for (int i = 0; i < Result.Count; i++)
                {
                    PlaceMS temp = new PlaceMS
                    {
                        Id = (int)Result[i]["Id"],
                        PlaceName = (string)Result[i]["PlaceName"],
                        Street = (string)Result[i]["Street"],
                        Number = (string)Result[i]["Number"],
                        IdLoc = (int)Result[i]["IdLoc"]
                    };
                    CurrentList.Add(temp);
                }
            }
            return CurrentList;
        }

        public bool Insert(PlaceMS item)
        {
            string Query = "INSERT INTO [Place] Values (";
            Query += "'" + item.PlaceName + "'";
            Query += ",'" + item.Street + "'";
            Query += ",'" + item.Number+"'";
            Query += "," + item.IdLoc;
            Query += ")";

            bool QueryResult = _con.Insert(Query);
            return QueryResult;
        }

        public bool Update(PlaceMS item)
        {
            string Query = "UPDATE [Place] SET";
            Query += "PlaceName = '" + item.PlaceName + "'";
            Query += ", Street = '" + item.Street + "'";
            Query += ", Number = '" + item.Number + "'";
            Query += ", IdLoc = " + item.IdLoc + "";
            Query += " WHERE Id=" + item.Id;

            bool QueryResult = _con.Insert(Query);
            return QueryResult;
        }
    }
}
