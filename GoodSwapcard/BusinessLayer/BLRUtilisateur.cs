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
    public class BLRUtilisateur : IRepository<UtilisateurMC, int>
    {
        RepoUtilisateur repo = new RepoUtilisateur();

        public UtilisateurMC Get(int id)
        {
            return MappingModel.UtilisateurStoC(repo.Get(id));
        }

        public List<UtilisateurMC> GetAll()
        {
            return repo.GetAll().Select(x => MappingModel.UtilisateurStoC(x)).ToList();
        }

        public bool Insert(UtilisateurMC item)
        {
            return repo.Insert(MappingModel.UtilisateurCtoS(item));
        }

        public bool Update(UtilisateurMC item)
        {
            return repo.Update(MappingModel.UtilisateurCtoS(item));
        }

        public bool Delete(int id)
        {
            return repo.Delete(id);
        }
    }
}
