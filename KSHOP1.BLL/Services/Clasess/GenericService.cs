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
        private readonly IGeneicRepository<TEntity> _geneicRepository;

        public GenericService(IGeneicRepository<TEntity> geneicRepository)
        {
            _geneicRepository = geneicRepository;
        }

        public int Create(TRequest request)
        {
            var entity = request.Adapt<TEntity>();

            return _geneicRepository.Add(entity);

        }

        public int Delete(int id)
        {
            var entity = _geneicRepository.GetById(id);
            if (entity == null)
            {
                throw new Exception("Entity not found");
            }
            return _geneicRepository.Remove(entity);
        }

        public IEnumerable<TResponse> GetAll()
        {
            var entities = _geneicRepository.GetAll();
            return entities.Adapt<IEnumerable<TResponse>>();
        }

        public TResponse? GetById(int id)
        {
            var entity = _geneicRepository.GetById(id);
            if (entity == null)
            {
                throw new Exception("Entity not found");
            }
            return entity.Adapt<TResponse>();
        }

        public bool ToggleStatus(int id)
        {
            var entity = _geneicRepository.GetById(id);
            if (entity == null)
            {
                throw new Exception("Entity not found");
            }
            entity.IsActive = !entity.IsActive;
            _geneicRepository.Update(entity);
            return entity.IsActive;
        }

        public int Update(int id, TRequest request)
        {
            var entity = _geneicRepository.GetById(id);
            if (entity == null)
            {
                throw new Exception("Entity not found");
            }
            var updatedEntity = request.Adapt<TEntity>();
            updatedEntity.Id = id;
            return _geneicRepository.Update(updatedEntity);
        }
    }
}
