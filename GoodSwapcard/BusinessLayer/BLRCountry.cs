using ModelClient;
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
        public CountryMC Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<CountryMC> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Insert(CountryMC item)
        {
            throw new NotImplementedException();
        }

        public bool Update(CountryMC item)
        {
            throw new NotImplementedException();
        }
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
