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
            string Query = "Delete from [Notifications] where [Id]=" + id;
            bool QueryState = _con.Delete(Query);
            return QueryState;
        }

        public NotifictionsMS Get(int id)
        {
            string Query = "Select * from [Notifications] where [Id] =" + id;
            List<Dictionary<string, object>> Result = _con.getData(Query);
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
            string Query = "INSERT INTO [Notifications] Values (";
            Query += "'" + item.Content + "',";
            Query += "" + item.IdUser + "";
            Query += ")";

            bool QueryResult = _con.Insert(Query);
            return QueryResult;
        }

        public bool Update(NotifictionsMS item)
        {
            string Query = "UPDATE [Notifications] SET";
            Query += "Content = '" + item.Content + "'";
            Query += ", IdUser = " + item.IdUser + "";
            Query += " WHERE Id=" + item.Id;

            bool QueryResult = _con.Insert(Query);
            return QueryResult;
        }
    }
}
