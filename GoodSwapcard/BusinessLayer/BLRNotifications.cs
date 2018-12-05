using ModelClient;
using ModelServer;
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


        public NotificationsMC Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<NotificationsMC> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Insert(NotificationsMC item)
        {
            throw new NotImplementedException();
        }

        public bool Update(NotificationsMC item)
        {
            throw new NotImplementedException();
        }
        public bool Delete(int id)
        {
            return true;
        }
    }
}
