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
    public class RepoEventUser : IRepository<EventUserMS, int>
    {
        private Connexion _con = new Connexion();

        public EventUserMS Get(int id)
        {
            List<Dictionary<string, Object>> list;
            EventUserMS eventUser = new EventUserMS();
            list = _con.getData("Select * from EventUser where Id = @0", id);

            eventUser.Id          = (int)  list[0]["Id"];
            eventUser.IdUser      = (int)  list[0]["IdUser"];
            eventUser.IdEvent     = (int)  list[0]["IdEvent"];
            eventUser.IdStatut    = (int)  list[0]["IdStatut"];

            return eventUser;
        }

        public List<EventUserMS> GetAll()
        {
            string Query = "Select * EventUser";
            List<Dictionary<string, object>> listResult = _con.getData(Query);
            List<EventUserMS> list = new List<EventUserMS>();

            if (listResult.Count != 0)
            {
                foreach (Dictionary<string, object> item in listResult)
                {
                    EventUserMS temp = new EventUserMS();

                    temp.Id         = (int)     item["Id"];
                    temp.IdUser     = (int)  item["IdUser"];
                    temp.IdEvent    = (int)  item["IdEvent"];
                    temp.IdStatut   = (int)  item["IdStatut"];


                    list.Add(temp);
                }
            }
            return list;
        }

        public bool Insert(EventUserMS eventUser)
        {
            string Query = "INSERT INTO [EventUser] Values( @0, @1, @2)";

            bool QueryResult = _con.Insert(Query, eventUser.IdUser, eventUser.IdEvent, eventUser.IdStatut);

            return QueryResult;
        }

        public bool Update(EventUserMS eventUser)
        {
            string Query = "UPDATE [EventUser] SET ";

            Query += "FirstName = @1 ";
            Query += ", PsW       = @2 ";
            Query += ", Email     = @3 ";

            Query += " WHERE Id = @0";

            bool QueryResult = _con.Update(Query,eventUser.Id, eventUser.IdUser, eventUser.IdEvent, eventUser.IdStatut);

            return QueryResult;
        }
        public bool Delete(int id)
        {
            bool QueryResult = _con.Insert("Delete from EventUser where Id= @", id);
            return QueryResult;
        }
    }
}
