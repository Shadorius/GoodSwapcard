using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repostory.Repository
{
    public interface IRepository<T, Tkey>
        where Tkey : struct
    {
        T Get(Tkey id);
        List<T> GetAll();
        bool Insert(T item);
        bool Update(T item);
        bool Delete(Tkey id);
    }
}
