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
            string Query = "Delete from [Locality] where [Id]= @0";
            bool QueryState = _con.Delete(Query, id);
            return QueryState;
        }

        public LocalityMS Get(int id)
        {
            string Query = "Select * from [Locality] where [Id] = @0";
            List<Dictionary<string, object>> Result = _con.getData(Query, id);
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
            string Query = "Select * from [Locality]";
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
            string Query = "INSERT INTO [Locality] Values (@0,@1,@3)";

            bool QueryResult = _con.Insert(Query, item.LocalityName, item.CP, item.IdCountry);
            return QueryResult;
        }

        public bool Update(LocalityMS item)
        {
            string Query = "UPDATE [Locality] SET ";
            Query += "LocalityName = @1";
            Query += ", CP = @2";
            Query += ", IdCountry = @3";
            Query += " WHERE Id= @0";

            bool QueryResult = _con.Update(Query, item.Id, item.LocalityName, item.CP, item.IdCountry);
            return QueryResult;
        }
    }
}
