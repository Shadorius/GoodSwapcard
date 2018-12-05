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
    public class BLRHourTime : IRepository<HourTimeMC, int>
    {
        RepoHourTime repo = new RepoHourTime();

        public HourTimeMC Get(int id)
        {
            return MappingModel.HourTimeStoC(repo.Get(id));
        }

        public List<HourTimeMC> GetAll()
        {
            return repo.GetAll().Select(x => MappingModel.HourTimeStoC(x)).ToList();
        }

        public bool Insert(HourTimeMC item)
        {
            return repo.Insert(MappingModel.HourTimeCtoS(item));
        }

        public bool Update(HourTimeMC item)
        {
            return repo.Update(MappingModel.HourTimeCtoS(item));
        }

        public bool Delete(int id)
        {
            return repo.Delete(id);
        }
    }
}
