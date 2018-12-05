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
    public class BLRLocality : IRepository<LocalityMC, int>
    {
        RepoLocality repo = new RepoLocality();

        public LocalityMC Get(int id)
        {
            return MappingModel.LocalityStoC(repo.Get(id));
        }

        public List<LocalityMC> GetAll()
        {
            return repo.GetAll().Select(x => MappingModel.LocalityStoC(x)).ToList();
        }

        public bool Insert(LocalityMC item)
        {
            return repo.Insert(MappingModel.LocalityCtoS(item));
        }

        public bool Update(LocalityMC item)
        {
            return repo.Update(MappingModel.LocalityCtoS(item));
        }

        public bool Delete(int id)
        {
            return repo.Delete(id);
        }
    }
}
