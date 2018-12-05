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
    public class BLRCountry : IRepository<CountryMC, int>
    {
        RepoCountry repo = new RepoCountry();

        public CountryMC Get(int id)
        {
            return MappingModel.CountryStoC(repo.Get(id));
        }

        public List<CountryMC> GetAll()
        {
            return repo.GetAll().Select(x => MappingModel.CountryStoC(x)).ToList();
        }

        public bool Insert(CountryMC item)
        {
            return repo.Insert(MappingModel.CountryCtoS(item));
        }

        public bool Update(CountryMC item)
        {
            return repo.Update(MappingModel.CountryCtoS(item));
        }
        public bool Delete(int id)
        {
            return repo.Delete(id);
        }
    }
}
