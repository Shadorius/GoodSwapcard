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
            string Query = "Delete from [Evenement] where [Id]=@0";
            bool QueryState = _con.Delete(Query, id);
            return QueryState;
        }

        public EvenementMS Get(int id)
        {
            List<Dictionary<string, object>> Result = _con.getData("Select * from [Evenement] where Id = @0", id);
            EvenementMS CurrentEvenement = null;

            if (Result.Count != 0)
            {
                CurrentEvenement = new EvenementMS
                {
                    Id = (int)Result[0]["Id"],
                    EvenementName = (string)Result[0]["EvenementName"],
                    EventDesc = (string)Result[0]["EventDesc"],
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
                        EventDesc = (string)Result[i]["EventDesc"],
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
            string Query = "INSERT INTO [Evenement](EvenementName, EventDesc, DateEvent, IdUserCreator, IdPlace) Values (@0, @1, @2, @3, @4)";

            bool QueryResult = _con.Insert(Query, item.EvenementName, item.EventDesc, item.DateEvent, item.IdUserCreator, item.IdPlace);
            return QueryResult;
        }

        public bool Update(EvenementMS item)
        {
            string Query = "UPDATE [Evenement] SET ";
            Query += "EvenementName = @1";
            Query += ", EventDesc = @2";
            Query += ", DateEvent = @3";
            Query += ", IdUserCreator = @4";
            Query += ", IdPlace = @5";
            Query += " WHERE Id=@0";

            bool QueryResult = _con.Update(Query, item.Id, item.EvenementName, item.EventDesc, item.DateEvent, item.IdUserCreator, item.IdPlace);

            return QueryResult;
        }
    }
}
