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
    public class BLRSociety : IRepository<SocietyMC, int>
    {
        RepoSociety repo = new RepoSociety();

        public SocietyMC Get(int id)
        {
            return MappingModel.SocietyStoC(repo.Get(id));
        }

        public List<SocietyMC> GetAll()
        {
            return repo.GetAll().Select(x => MappingModel.SocietyStoC(x)).ToList();
        }

        public bool Insert(SocietyMC item)
        {
            return repo.Insert(MappingModel.SocietyCtoS(item));
        }

        public bool Update(SocietyMC item)
        {
            return repo.Update(MappingModel.SocietyCtoS(item));
        }

        public bool Delete(int id)
        {
            return repo.Delete(id);
        }
    }
}
