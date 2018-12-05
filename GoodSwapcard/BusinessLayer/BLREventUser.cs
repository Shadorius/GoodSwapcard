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
    public class BLREventUser : IRepository<EventUserMC, int>
    {
        RepoEventUser repo = new RepoEventUser();

        public EventUserMC Get(int id)
        {
            return MappingModel.EventUserStoC(repo.Get(id));
        }

        public List<EventUserMC> GetAll()
        {
            return repo.GetAll().Select(x => MappingModel.EventUserStoC(x)).ToList();
        }

        public bool Insert(EventUserMC item)
        {
            return repo.Insert(MappingModel.EventUserCtoS(item));
        }

        public bool Update(EventUserMC item)
        {
            return repo.Update(MappingModel.EventUserCtoS(item));
        }

        public bool Delete(int id)
        {
            return repo.Delete(id);
        }
    }
}
