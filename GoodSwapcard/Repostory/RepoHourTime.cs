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
    public class RepoHourTime : IRepository<HourTimeMS, int>
    {
        private Connexion _con = new Connexion();
        public bool Delete(int id)
        {
            string Query = "Delete from [HourTime] where [Id]=" + id;
            bool QueryState = _con.Delete(Query);
            return QueryState;
        }

        public HourTimeMS Get(int id)
        {
            string Query = "Select * from [Evenement] where [Id] =" + id;
            List<Dictionary<string, object>> Result = _con.getData(Query);
            HourTimeMS CurrentHourTime = null;

            if (Result.Count != 0)
            {
                CurrentHourTime = new HourTimeMS
                {
                    Id = (int)Result[0]["Id"],
                    Hour = (int)Result[0]["Hour"],
                    Minute = (int)Result[0]["Minute"]
                };
            }
            return CurrentHourTime;
        }

        public List<HourTimeMS> GetAll()
        {
            string Query = "Select * from [HourTime]";
            List<Dictionary<string, object>> Result = _con.getData(Query);
            List<HourTimeMS> CurrentList = new List<HourTimeMS>();
            if (Result.Count != 0)
            {
                for (int i = 0; i < Result.Count; i++)
                {
                    HourTimeMS temp = new HourTimeMS
                    {
                        Id = (int)Result[i]["Id"],
                        Hour = (int)Result[i]["Hour"],
                        Minute = (int)Result[i]["Minute"]
                    };
                    CurrentList.Add(temp);
                }
            }
            return CurrentList;
        }

        public bool Insert(HourTimeMS item)
        {
            string Query = "INSERT INTO [HourTime] Values (";
            Query += "" + item.Hour + ",";
            Query += "" + item.Minute;
            Query += ")";

            bool QueryResult = _con.Insert(Query);
            return QueryResult;
        }

        public bool Update(HourTimeMS item)
        {
            string Query = "UPDATE [HourTime] SET";
            Query += "[Hour] = " + item.Hour + "";
            Query += ", [Minute] = " + item.Minute + "";
            Query += " WHERE Id=" + item.Id;

            bool QueryResult = _con.Insert(Query);
            return QueryResult;
        }
    }
}
