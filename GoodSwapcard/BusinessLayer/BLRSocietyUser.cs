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
    public class BLRSocietyUser : IRepository<SocietyUserMC, int>
    {
        RepoSocietyUser repo = new RepoSocietyUser();

        public SocietyUserMC Get(int id)
        {
            return MappingModel.SocietyUserStoC(repo.Get(id));
        }

        public List<SocietyUserMC> GetAll()
        {
            return repo.GetAll().Select(x => MappingModel.SocietyUserStoC(x)).ToList();
        }

        public List<SocietyUserMC> GetAllById(int id)
        {
            return repo.GetAllById(id).Select(x => MappingModel.SocietyUserStoC(x)).ToList();
        }

        public bool Insert(SocietyUserMC item)
        {
            return repo.Insert(MappingModel.SocietyUserCtoS(item));
        }

        public bool Update(SocietyUserMC item)
        {
            return repo.Update(MappingModel.SocietyUserCtoS(item));
        }

        public bool Delete(int id)
        {
            return repo.Delete(id);
        }
    }
}
