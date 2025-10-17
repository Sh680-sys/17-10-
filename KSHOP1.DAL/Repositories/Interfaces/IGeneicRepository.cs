using KSHOP1.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSHOP1.DAL.Repositories.Interfaces
{
    public interface IGeneicRepository<T> where T : BaseModel 

    {
        int Add(T category);
        IEnumerable<T> GetAll(bool withTracking = false);

        T? GetById(int id);

        int Remove(T entity);
        int Update(T entity);
    }
}
