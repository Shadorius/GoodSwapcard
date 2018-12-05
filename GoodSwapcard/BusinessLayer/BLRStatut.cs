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
    public class BLRStatut : IRepository<StatutMC, int>
    {
        RepoStatut repo = new RepoStatut();
        
        public StatutMC Get(int id)
        {
            return MappingModel.StatutStoC(repo.Get(id));
        }

        public List<StatutMC> GetAll()
        {
            return repo.GetAll().Select(x => MappingModel.StatutStoC(x)).ToList();
        }

        public bool Insert(StatutMC item)
        {
            return repo.Insert(MappingModel.StatutCtoS(item));
        }

        public bool Update(StatutMC item)
        {
            return repo.Update(MappingModel.StatutCtoS(item));
        }
        public bool Delete(int id)
        {
            return repo.Delete(id);
        }

    }
}
