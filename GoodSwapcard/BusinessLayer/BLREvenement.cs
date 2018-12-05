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
    public class BLREvenement : IRepository<EvenementMC, int>
    {
        RepoEvenement repo = new RepoEvenement();

        public EvenementMC Get(int id)
        {
            return MappingModel.EvenementStoC(repo.Get(id));
        }

        public List<EvenementMC> GetAll()
        {
            return repo.GetAll().Select(x => MappingModel.EvenementStoC(x)).ToList();
        }

        public bool Insert(EvenementMC item)
        {
            return repo.Insert(MappingModel.EvenementCtoS(item));
        }

        public bool Update(EvenementMC item)
        {
            return repo.Update(MappingModel.EvenementCtoS(item));
        }

        public bool Delete(int id)
        {
            return repo.Delete(id);
        }
    }
}
