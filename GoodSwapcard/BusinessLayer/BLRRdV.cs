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
    public class BLRRdV : IRepository<RdVMC, int>
    {
        RepoRDV repo = new RepoRDV();
        public RdVMC Get(int id)
        {
            return MappingModel.RdVStoC(repo.Get(id));
        }

        public List<RdVMC> GetAll()
        {
            return repo.GetAll().Select(x => MappingModel.RdVStoC(x)).ToList();
        }

        public bool Insert(RdVMC item)
        {
            return repo.Insert(MappingModel.RdVCtoS(item));
        }

        public bool Update(RdVMC item)
        {
            return repo.Update(MappingModel.RdVCtoS(item));
        }
        public bool Delete(int id)
        {
            return repo.Delete(id);
        }
    }
}
