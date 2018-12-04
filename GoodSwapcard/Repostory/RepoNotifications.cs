using DAL;
using Repostory.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repostory
{
    public class RepoNotifications : IRepository<NotificationsMS, int>
    {
        private Connexion _con = new Connexion();
        public bool Delete(int id)
        {
            string Query = "Delete from [Notifications] where [Id]=" + id;
            bool QueryState = _con.Delete(Query);
            return QueryState;
        }

        public NotificationsMS Get(int id)
        {
            string Query = "Select * from [Notifications] where [Id] =" + id;
            List<Dictionary<string, object>> Result = _con.getData(Query);
            NotificationsMS CurrentNotif = null;

            if (Result.Count != 0)
            {
                CurrentNotif = new NotificationsMS
                {
                    Id = (int)Result[0]["Id"],
                    Content = (string)Result[0]["Content"],
                    IdUser = (int)Result[0]["IdUser"]
                };
            }

            return CurrentNotif;
        }

        public List<NotificationsMS> GetAll()
        {
            string Query = "Select * from [Country]";
            List<Dictionary<string, object>> Result = _con.getData(Query);
            List<NotificationsMS> CurrentList = new List<NotificationsMS>();
            if (Result.Count != 0)
            {
                for (int i = 0; i < Result.Count; i++)
                {
                    NotificationsMS temp = new NotificationsMS
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

        public bool Insert(NotificationsMS item)
        {
            
            throw new NotImplementedException();
        }

        public bool Update(NotificationsMS item)
        {
            throw new NotImplementedException();
        }
    }
}
