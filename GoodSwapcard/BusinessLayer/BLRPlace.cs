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
    public class BLRPlace : IRepository<PlaceMC, int>
    {
        RepoPlace repo = new RepoPlace();
        
        public PlaceMC Get(int id)
        {
            return MappingModel.PlaceStoC(repo.Get(id));
        }

        public List<PlaceMC> GetAll()
        {
            return repo.GetAll().Select(x => MappingModel.PlaceStoC(x)).ToList();
        }

        public bool Insert(PlaceMC item)
        {
            return repo.Insert(MappingModel.PlaceCtoS(item));
        }

        public bool Update(PlaceMC item)
        {
            return repo.Update(MappingModel.PlaceCtoS(item));
        }
        public bool Delete(int id)
        {
            return repo.Delete(id);
        }

    }
}
