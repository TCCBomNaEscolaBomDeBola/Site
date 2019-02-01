using AraretamaRepositoy;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Araretama.Common.Repository.Entity
{
    public abstract class AbstractRepository<TEntity, TKey> : IAraretamaCommonRepository<TEntity, TKey>
        where TEntity : class
    {

        private DbContext _context;

        public AbstractRepository(DbContext dbContext)
        {
            _context = dbContext;
        }

        public List<TEntity> All()
        {
            return _context.Set<TEntity>().ToList();
        }

        public virtual TEntity ByKey(TKey key)
        {
            return _context.Set<TEntity>().Find(key);

        }

 

        public void Delete(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public void DeleteByKey(TKey key)
        {
            TEntity entity = ByKey(key);
            Delete(entity);
        }

        public void Insert(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

    }
}