using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Capinfo.His
{
    public class CapinfoRepositoryBase<IEntity> : IRepository<IEntity, int> where IEntity : class, IEntity<int>
    {
        public int Count()
        {
            throw new NotImplementedException();
        }

        public int Count(Expression<Func<IEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync(Expression<Func<IEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Delete(IEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(Expression<Func<IEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(IEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Expression<Func<IEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEntity FirstOrDefault(int id)
        {
            throw new NotImplementedException();
        }

        public IEntity FirstOrDefault(Expression<Func<IEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEntity> FirstOrDefaultAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEntity> FirstOrDefaultAsync(Expression<Func<IEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEntity Get(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<IEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<IEntity> GetAllIncluding(params Expression<Func<IEntity, object>>[] propertySelectors)
        {
            throw new NotImplementedException();
        }

        public List<IEntity> GetAllList()
        {
            throw new NotImplementedException();
        }

        public List<IEntity> GetAllList(Expression<Func<IEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<List<IEntity>> GetAllListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<IEntity>> GetAllListAsync(Expression<Func<IEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEntity> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IEntity Insert(IEntity entity)
        {
            throw new NotImplementedException();
        }

        public int InsertAndGetId(IEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertAndGetIdAsync(IEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEntity> InsertAsync(IEntity entity)
        {
            throw new NotImplementedException();
        }

        public IEntity InsertOrUpdate(IEntity entity)
        {
            throw new NotImplementedException();
        }

        public int InsertOrUpdateAndGetId(IEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertOrUpdateAndGetIdAsync(IEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEntity> InsertOrUpdateAsync(IEntity entity)
        {
            throw new NotImplementedException();
        }

        public IEntity Load(int id)
        {
            throw new NotImplementedException();
        }

        public long LongCount()
        {
            throw new NotImplementedException();
        }

        public long LongCount(Expression<Func<IEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<long> LongCountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<long> LongCountAsync(Expression<Func<IEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public T Query<T>(Func<IQueryable<IEntity>, T> queryMethod)
        {
            throw new NotImplementedException();
        }

        public IEntity Single(Expression<Func<IEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEntity> SingleAsync(Expression<Func<IEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEntity Update(IEntity entity)
        {
            throw new NotImplementedException();
        }

        public IEntity Update(int id, Action<IEntity> updateAction)
        {
            throw new NotImplementedException();
        }

        public Task<IEntity> UpdateAsync(IEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEntity> UpdateAsync(int id, Func<IEntity, Task> updateAction)
        {
            throw new NotImplementedException();
        }
    }
}
