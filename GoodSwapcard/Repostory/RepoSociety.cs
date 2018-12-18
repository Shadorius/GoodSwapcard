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
    public class RepoSociety : IRepository<SocietyMS, int>
    {
        private Connexion con = new Connexion();

        public bool Delete(int id)
        {
            string Query = "DELETE FROM [Society] WHERE [Id]= @0";
            bool QueryState = con.Delete(Query, id);
            return QueryState;
        }

        public SocietyMS Get(int id)
        {
            string Query = "Select * from [Society] where [Id] = @0";
            List<Dictionary<string, object>> Result = con.getData(Query, id);
            SocietyMS society = null;

            if (Result.Count != 0)
            {
                society = new SocietyMS
                {
                    Id = (int)Result[0]["Id"],
                    SocietyName = (string)Result[0]["SocietyName"],
                    SocietyDesc = (string)Result[0]["SocietyDesc"],
                    SocietyTinyDesc = (string)Result[0]["SocietyTinyDesc"],
                    Img = (string)Result[0]["Img"],
                    WebSite = (string)Result[0]["WebSite"],
                    Phone = (string)Result[0]["Phone"],
                    Street = (string)Result[0]["Street"],
                    Number = (string)Result[0]["Number"],
                    IdLoc = (int)Result[0]["IdLoc"],
                    IdBoss = (int)Result[0]["IdBoss"]
                };
            }

            return society;
        }

        public List<SocietyMS> GetAll()
        {
            string Query = "Select * from [Society]";
            List<Dictionary<string, object>> Result = con.getData(Query);
            List<SocietyMS> CurrentList = new List<SocietyMS>();

            if (Result.Count != 0)
            {
                for (int i = 0; i < Result.Count; i++)
                {
                    SocietyMS society = new SocietyMS {
                        Id = (int)Result[i]["Id"],
                        SocietyName = (string)Result[i]["SocietyName"],
                        SocietyDesc = (string)Result[i]["SocietyDesc"],
                        SocietyTinyDesc = (string)Result[i]["SocietyTinyDesc"],
                        Img = (string)Result[i]["Img"],
                        WebSite = (string)Result[i]["WebSite"],
                        Phone = (string)Result[i]["Phone"],
                        Street = (string)Result[i]["Street"],
                        Number = (string)Result[i]["Number"],
                        IdLoc = (int)Result[i]["IdLoc"],
                        IdBoss = (int)Result[i]["IdBoss"]
                    };
                    CurrentList.Add(society);
                }
            }
            return CurrentList;
        }

        public bool Insert(SocietyMS item)
        {
            string Query = "INSERT INTO [Society] Values (@0, @1, @2, @3, @4, @5, @6, @7, @8, @9)";
            bool QueryResult = con.Insert(Query, item.SocietyName, item.SocietyDesc, item.SocietyTinyDesc, item.Img, item.WebSite, item.Phone, item.Street, item.IdLoc, item.IdBoss);
            return QueryResult;
        }

        public bool Update(SocietyMS item)
        {
            
            string Query = "UPDATE [Society] SET ";
            Query += "SocietyName = @1,";
            Query += "SocietyDesc = @2,";
            Query += "SocietyTinyDesc = @3,";
            Query += "Img = @4,";
            Query += "WebSite = @5,";
            Query += "Phone = @6,";
            Query += "Street = @7,";
            Query += "Number = @8,";
            Query += "IdLoc = @9,";
            Query += "IdBoss = @10";
            Query += " WHERE Id= @0";
           
            bool QueryResult = con.Update(Query, item.Id,item.SocietyName, item.SocietyDesc, item.SocietyTinyDesc, item.Img, item.WebSite, item.Phone, item.Street,item.Number, item.IdLoc, item.IdBoss);

            return QueryResult;
        }
    }
}
