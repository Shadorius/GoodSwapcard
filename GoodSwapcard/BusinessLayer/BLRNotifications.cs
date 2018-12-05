using ModelClient;
using Repostory;
using Repostory.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BLRNotifications : IRepository<NotificationsMC, int>
    {

        RepoNotifications repo = new RepoNotifications();
        

        public NotificationsMC Get(int id)
        {
            return MappingModel.NotifictionsStoC(repo.Get(id));
        }

        public List<NotificationsMC> GetAll()
        {
            return repo.GetAll().Select(x => MappingModel.NotifictionsStoC(x)).ToList();
        }

        public bool Insert(NotificationsMC item)
        {
            return repo.Insert(MappingModel.NotifictionsCtoS(item));
        }

        public bool Update(NotificationsMC item)
        {
            return repo.Update(MappingModel.NotifictionsCtoS(item));
        }
        public bool Delete(int id)
        {
            return repo.Delete(id);
        }
    }
}
