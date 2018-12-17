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
    public class RepoNotifications : IRepository<NotifictionsMS, int>
    {
        private Connexion _con = new Connexion();
        public bool Delete(int id)
        {
            string Query = "Delete from [Notifications] where [Id]= @0";
            bool QueryState = _con.Delete(Query, id);
            return QueryState;
        }

        public NotifictionsMS Get(int id)
        {
            string Query = "Select * from [Notifications] where [Id] = @0";
            List<Dictionary<string, object>> Result = _con.getData(Query,id);
            NotifictionsMS CurrentNotif = null;

            if (Result.Count != 0)
            {
                CurrentNotif = new NotifictionsMS
                {
                    Id = (int)Result[0]["Id"],
                    Content = (string)Result[0]["Content"],
                    IdUser = (int)Result[0]["IdUser"]
                };
            }

            return CurrentNotif;
        }

        public List<NotifictionsMS> GetAll()
        {
            string Query = "Select * from [Notifications]";
            List<Dictionary<string, object>> Result = _con.getData(Query);
            List<NotifictionsMS> CurrentList = new List<NotifictionsMS>();
            if (Result.Count != 0)
            {
                for (int i = 0; i < Result.Count; i++)
                {
                    NotifictionsMS temp = new NotifictionsMS
                    {
                        Id = (int)Result[i]["Id"],
                        Content = (string)Result[i]["Content"],
                        IdUser = (int)Result[i]["IdUser"]
                    };
                    CurrentList.Add(temp);
                }
            }
            return CurrentList;
        }

        public bool Insert(NotifictionsMS item)
        {
            string Query = "INSERT INTO [Notifications] Values (@0,@1)";
            
            bool QueryResult = _con.Insert(Query, item.Content, item.IdUser);
            return QueryResult;
        }

        public bool Update(NotifictionsMS item)
        {
            string Query = "UPDATE [Notifications] SET ";
            Query += "Content = @1";
            Query += ", IdUser = @2";
            Query += " WHERE Id=@0";

            bool QueryResult = _con.Update(Query, item.Id, item.Content, item.IdUser);
            return QueryResult;
        }
    }
}
