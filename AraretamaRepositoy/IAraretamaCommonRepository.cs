using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AraretamaRepositoy
{
    public interface IAraretamaCommonRepository<TEntity, TKey>
    where TEntity : class
    {
       
        List<TEntity> All();

        TEntity ByKey(TKey key);
        
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void DeleteByKey(TKey key);

        
    }
}
