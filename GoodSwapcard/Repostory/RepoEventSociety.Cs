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
    public class RepoEventSociety : IRepository<EventSocietyMS, int>
    {
        private Connexion con = new Connexion();
        public bool Delete(int id)
        {
            string Query = "DELETE FROM [EventSoc] WHERE [Id]= @0";
            bool QueryState = con.Delete(Query, id);
            return QueryState;
        }

        public EventSocietyMS Get(int id)
        {
            string Query = "Select * from [EventSoc] where [Id] = @0";
            List<Dictionary<string, object>> Result = con.getData(Query, id);
            EventSocietyMS currentEventSoc = null;

            if (Result.Count != 0)
            {
                currentEventSoc = new EventSocietyMS
                {
                    Id = (int)Result[0]["Id"],
                    IdSociety = (int)Result[0]["IdSociety"],
                    IdEvent = (int)Result[0]["IdEvent"]
                };
            }

            return currentEventSoc;
        }

        public List<EventSocietyMS> GetAll()
        {
            string Query = "Select * from [EventSoc]";
            List<Dictionary<string, object>> Result = con.getData(Query);
            List<EventSocietyMS> CurrentList = new List<EventSocietyMS>();

            if (Result.Count != 0)
            {
                for (int i = 0; i < Result.Count; i++)
                {
                    EventSocietyMS societyUser = new EventSocietyMS
                    {
                        Id = (int)Result[i]["Id"],
                        IdSociety = (int)Result[i]["IdSociety"],
                        IdEvent = (int)Result[i]["IdEvent"]
                    };
                    CurrentList.Add(societyUser);
                }
            }
            return CurrentList;
        }

        public List<EventSocietyMS> GetAllById(int id)
        {
            string Query = "Select * from [EventSoc]";
            List<Dictionary<string, object>> Result = con.getData(Query);
            List<EventSocietyMS> CurrentList = new List<EventSocietyMS>();

            if (Result.Count != 0)
            {
                for (int i = 0; i < Result.Count; i++)
                {
                    EventSocietyMS societyUser = new EventSocietyMS
                    {
                        Id = (int)Result[i]["Id"],
                        IdSociety = (int)Result[i]["IdSociety"],
                        IdEvent = (int)Result[i]["IdEvent"]
                    };
                    CurrentList.Add(societyUser);
                }
            }
            return CurrentList;
        }

        public bool Insert(EventSocietyMS item)
        {
            string Query = "INSERT INTO [EventSoc] Values (@0,@1)";

            bool QueryResult = con.Insert(Query, item.IdSociety, item.IdEvent);
            return QueryResult;
        }

        public bool Update(EventSocietyMS item)
        {
            string Query = "UPDATE [SocietyUser] SET";
            Query += " IdSociety = @1";
            Query += " IdEvent = @2";
            Query += " WHERE Id= @0";

            bool QueryResult = con.Update(Query, item.Id, item.IdSociety, item.IdEvent);

            return QueryResult;
        }
    }
}
