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
    public class BLRMessagerie : IRepository<MessagerieMC, int>
    {
        private RepoMessagerie _repo = new RepoMessagerie();
        public MessagerieMC Get(int id)
        {
            return MappingModel.MessagerieStoC(_repo.Get(id));
        }

        public List<MessagerieMC> GetAll()
        {
            return _repo.GetAll().Select(x => MappingModel.MessagerieStoC(x)).ToList();
        }

        public bool Insert(MessagerieMC item)
        {
            return _repo.Insert(MappingModel.MessagerieCtoS(item));
        }

        public bool Update(MessagerieMC item)
        {
            return _repo.Insert(MappingModel.MessagerieCtoS(item));
        }
        public bool Delete(int id)
        {
            return _repo.Delete(id);
        }

    }
}
