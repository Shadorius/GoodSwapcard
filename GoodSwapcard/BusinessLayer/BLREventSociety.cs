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
    public class BLREventSociety : IRepository<EventSocietyMC, int>
    {
        RepoEventSociety repo = new RepoEventSociety();
        
        public EventSocietyMC Get(int id)
        {
            return MappingModel.EventSocStoC(repo.Get(id));
        }

        public List<EventSocietyMC> GetAll()
        {
            return repo.GetAll().Select(x => MappingModel.EventSocStoC(x)).ToList();
        }

        public List<EventSocietyMC> GetAllById(int id)
        {
            return repo.GetAllById(id).Select(x => MappingModel.EventSocStoC(x)).ToList();
        }

        public bool Insert(EventSocietyMC item)
        {
            return repo.Insert(MappingModel.EventSocCtoS(item));
        }

        public bool Update(EventSocietyMC item)
        {
            return repo.Update(MappingModel.EventSocCtoS(item));
        }
        public bool Delete(int id)
        {
            return repo.Delete(id);
        }
    }
}
