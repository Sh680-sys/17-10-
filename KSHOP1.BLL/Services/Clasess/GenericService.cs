using KSHOP1.BLL.Services.Interfaces;
using KSHOP1.DAL.Models;
using KSHOP1.DAL.Repositories.Classes;
using KSHOP1.DAL.Repositories.Interfaces;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSHOP1.BLL.Services.Clasess
{
    public class GenericService<TRequest, TResponse, TEntity> : IGenericService<TRequest, TResponse, TEntity> where TEntity : BaseModel
    {
        private readonly IGenericRepository<TEntity> _genericRepository;

        public GenericService(IGenericRepository<TEntity> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public int Create(TRequest request)
        {
            var entity = request.Adapt<TEntity>();

            return _genericRepository.Add(entity);

        }

        public int Delete(int id)
        {
            var entity = _genericRepository.GetById(id);
            if (entity == null)
            {
                throw new Exception("Entity not found");
            }
            return _genericRepository.Remove(entity);
        }

        public IEnumerable<TResponse> GetAll()
        {
            var entities = _genericRepository.GetAll();
            return entities.Adapt<IEnumerable<TResponse>>();
        }

        public TResponse? GetById(int id)
        {
            var entity = _genericRepository.GetById(id);
            if (entity == null)
            {
                throw new Exception("Entity not found");
            }
            return entity.Adapt<TResponse>();
        }

        public bool ToggleStatus(int id)
        {
            var entity = _genericRepository.GetById(id);
            if (entity == null)
            {
                throw new Exception("Entity not found");
            }
            entity.IsActive = !entity.IsActive;
            _genericRepository.Update(entity);
            return entity.IsActive;
        }

        public int Update(int id, TRequest request)
        {
            var entity = _genericRepository.GetById(id);
            if (entity == null)
            {
                throw new Exception("Entity not found");
            }
            var updatedEntity = request.Adapt<TEntity>();
            updatedEntity.Id = id;
            return _genericRepository.Update(updatedEntity);
        }
    }
}
