using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Ticari.DataAccsessLayer.GenericRepository.ECore.Abstract;
using Ticari.Entities.DBContexts;
using Ticari.Entities.Entities.Abstract;


namespace Ticari.DataAccsessLayer.GenericRepository.ECore.Concrete
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {

        readonly SQLDbContext _dbContext;
        public Repository()
        {
            _dbContext = new SQLDbContext();
        }

        #region Crud işlemleri
        public int Create(T entity)
        {

            // burdaki set<t>metodu dbcontext içerisindeki DbSet<T>
           _dbContext.Set<T>().Add(entity);
            return _dbContext.SaveChanges();
        }

        public int Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            return _dbContext.SaveChanges();
        }
        public int Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            return _dbContext.SaveChanges();
        }
        #endregion
        #region select metodları
        public List<T>? GetAll(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return _dbContext.Set<T>().Where(predicate).ToList();
            }
            return _dbContext.Set<T>().ToList();
        }

        public IQueryable<T>? GetAllInclude(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] include)
        {
            IQueryable<T> query = _dbContext.Set<T>(); // Initialize the query

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return include.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }


        public T GetById(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public T? Get(Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>().FirstOrDefault(predicate);
        }
        #endregion
    }
}
