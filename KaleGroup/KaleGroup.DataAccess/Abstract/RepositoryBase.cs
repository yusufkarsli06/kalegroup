using KaleGroup.Data.Abstract;
using KaleGroup.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KaleGroup.DataAccess.Abstract
{

    public class Repository<T> : IRepository<T> where T : class
    {
        #region Fields
        private readonly BaseContext _dbContext;
        internal DbSet<T> _dbSet;

        public IQueryable<T> Table
        {
            get
            {
                return _dbSet.AsNoTracking();
            }
        }
        #endregion
        #region Ctor
        public Repository(BaseContext dbContext)
        {
            _dbContext = dbContext;
            this._dbSet = _dbContext.Set<T>();
        }
        #endregion
        public void Delete(Guid Id)
        {
            T entity = _dbSet.Find(Id);
            Delete(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
            Save();
        }

        public async Task DeleteAsync(Guid Id)
        {
            T entity = await _dbSet.FindAsync(Id);
            Delete(entity);
        }

        public void DeleteRange(IEnumerable<T> entity)
        {
            _dbSet.RemoveRange(entity);
            _dbContext.SaveChanges();
        }
        public async Task<string> DeleteRangeAsync(IEnumerable<T> entity)
        {
            _dbSet.RemoveRange(entity);
            await _dbContext.SaveChangesAsync();
            return await Task.FromResult("Ok");
        }
        public T GetById(Guid Id)
        {
            return _dbSet.Find(Id);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null)
        {
            IQueryable<T> query = _dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includeProperties != null)
            {
                foreach (var item in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }
            }
            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<T> query = _dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includeProperties != null)
            {
                foreach (var item in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }
            }
            return query.FirstOrDefault();
        }

        public void Insert(T entity)
        {
            _dbSet.Add(entity);
            Save();
        }

        public async Task<T> InsertAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await SaveAsync();
            return entity;
        }
        public async Task<bool> InsertRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            await SaveAsync();
            return true;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            Save();

        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await SaveAsync();
        }

        public async Task<T> GetByIdAsync(int Id)
        {
            return await _dbSet.FindAsync(Id);
        }


    }
}
