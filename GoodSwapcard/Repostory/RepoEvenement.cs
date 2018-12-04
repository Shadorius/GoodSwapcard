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
    public class RepoEvenement : IRepository<EvenementMS, int>
    {
        private Connexion _con = new Connexion();
        public bool Delete(int id)
        {
            string Query = "Delete from [Evenement] where [Id]=" + id;
            bool QueryState = _con.Delete(Query);
            return QueryState;
        }

        public EvenementMS Get(int id)
        {
            string Query = "Select * from [Evenement] where [Id] =" + id;
            List<Dictionary<string, object>> Result = _con.getData(Query);
            EvenementMS CurrentEvenement = null;

            if (Result.Count != 0)
            {
                CurrentEvenement = new EvenementMS
                {
                    Id = (int)Result[0]["Id"],
                    EvenementName = (string)Result[0]["EvenementName"],
                    DateEvent = (DateTime?)Result[0]["DateEvent"],
                    IdUserCreator = (int)Result[0]["IdUserCreator"],
                    IdPlace = (int)Result[0]["IdPlace"]
                };
            }
            return CurrentEvenement;
        }

        public List<EvenementMS> GetAll()
        {
            string Query = "Select * from [Evenement]";
            List<Dictionary<string, object>> Result = _con.getData(Query);
            List<EvenementMS> CurrentList = new List<EvenementMS>();
            if (Result.Count != 0)
            {
                for (int i = 0; i < Result.Count; i++)
                {
                    EvenementMS temp = new EvenementMS
                    {
                        Id = (int)Result[i]["Id"],
                        EvenementName = (string)Result[i]["EvenementName"],
                        DateEvent = (DateTime?)Result[i]["DateEvent"],
                        IdUserCreator = (int)Result[i]["IdUserCreator"],
                        IdPlace = (int)Result[i]["IdPlace"]
                    };
                    CurrentList.Add(temp);
                }
            }
            return CurrentList;
        }

        public bool Insert(EvenementMS item)
        {
            string Query = "INSERT INTO [Evenement] Values (";
            Query += "'" + item.EvenementName + "',";
            Query += "'" + item.DateEvent.ToString() + "'";
            Query += "," + item.IdUserCreator;
            Query += "," + item.IdPlace;
            Query += ")";

            bool QueryResult = _con.Insert(Query);
            return QueryResult;
        }

        public bool Update(EvenementMS item)
        {
            string Query = "UPDATE [Evenement] SET";
            Query += "EvenementName = '" + item.EvenementName + "'";
            Query += ", DateEvent = '" + item.DateEvent.ToString() + "'";
            Query += ", IdUserCreator = " + item.IdUserCreator + "";
            Query += ", IdPlace = " + item.IdPlace + "";
            Query += " WHERE Id=" + item.Id;

            bool QueryResult = _con.Insert(Query);
            return QueryResult;
        }
    }
}
