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
    class BLRStatutEvent : IRepository<StatutEventMC, int>
    {
        RepoStatutEvent repo = new RepoStatutEvent();

        public StatutEventMC Get(int id)
        {
            return MappingModel.StatutEventStoC(repo.Get(id));
        }

        public List<StatutEventMC> GetAll()
        {
            return repo.GetAll().Select(x => MappingModel.StatutEventStoC(x)).ToList();
        }

        public bool Insert(StatutEventMC item)
        {
            return repo.Insert(MappingModel.StatutEventCtoS(item));
        }

        public bool Update(StatutEventMC item)
        {
            return repo.Update(MappingModel.StatutEventCtoS(item));
        }

        public bool Delete(int id)
        {
            return repo.Delete(id);
        }
    }
}
