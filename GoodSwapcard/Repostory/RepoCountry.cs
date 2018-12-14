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
    public class RepoCountry : IRepository<CountryMS, int>
    {
        private Connexion _con = new Connexion();

        public CountryMS Get(int id)
        {
            List<Dictionary<string, object>> Result = _con.getData("Select * from [Country] where Id = @0", id);
            CountryMS CurrentCountry = null;

            if (Result.Count != 0)
            {
                CurrentCountry = new CountryMS
                {
                    Id = (int)Result[0]["Id"],
                    CountryName = (string)Result[0]["CountryName"]
                };
            }

            return CurrentCountry;
        }

        public List<CountryMS> GetAll()
        {
            string Query = "Select * from [Country]";
            List<Dictionary<string, object>> Result = _con.getData(Query);
            List<CountryMS> CurrentList = new List<CountryMS>();
            if (Result.Count != 0)
            {
                for (int i = 0; i < Result.Count; i++)
                {
                    CountryMS temp = new CountryMS
                    {
                        Id = (int)Result[i]["Id"],
                        CountryName = (string)Result[i]["CountryName"]
                    };
                    CurrentList.Add(temp);
                }
            }
            return CurrentList;
        }

        public bool Insert(CountryMS item)
        {
            string Query = "INSERT INTO (CountryName) [Country] Values(@0)";

            bool QueryResult = _con.Insert(Query,item.CountryName);
            return QueryResult;
        }

        public bool Update(CountryMS item)
        {
            string Query = "UPDATE [Country] SET CountryName = @1 ";
            Query += " Where Id= @0";

            bool QueryResult = _con.Update(Query, item.Id, item.CountryName);
            return QueryResult;
        }

        public bool Delete(int id)
        {
            string Query = "Delete from [Country] where [Id]= @0";
            bool QueryState = _con.Delete(Query, id);
            return QueryState;
        }
    }
}
