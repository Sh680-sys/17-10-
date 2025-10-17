using KSHOP1.DAL.Data;
using KSHOP1.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSHOP1.DAL.Repositories.Classes
{
    public class GeneicRepository <T> where T : BaseModel
    {
        private readonly ApplicationDbContext dbContext;
        public GeneicRepository (ApplicationDbContext context)
        {
            dbContext = context;
        }
        public int Add(T  entity)
        {
            dbContext.Set<T>().Add(entity);
            return dbContext.SaveChanges();

        }

        public IEnumerable<T> GetAll(bool withTracking = false)
        {
            if (!withTracking)
            {
                return dbContext.Set<T>().AsNoTracking().ToList();
            }
            return  dbContext.Set<T>().ToList();

        }

        public T? GetById(int id) 
        {
            return dbContext.Set<T>().Find(id);
        }

        public int Remove(T entity)
        {

            dbContext.Set<T>().Remove(entity);
            return dbContext.SaveChanges();
        }


        public int Update(T entity)
        {

            dbContext.Set<T>().Update(entity);
            return dbContext.SaveChanges();
        }
    }
}

