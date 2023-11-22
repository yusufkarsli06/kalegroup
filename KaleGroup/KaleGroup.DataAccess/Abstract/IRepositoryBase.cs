using KaleGroup.Data.Abstract;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KaleGroup.DataAccess.Abstract
{
    public interface IRepository<T> where T : class
    {
        T GetById(int Id);
        Task<T> GetByIdAsync(int Id);
        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null);
        T GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null);
        IQueryable<T> Table { get; }
        void Insert(T entity);
        Task<T> InsertAsync(T entity);
        Task<bool> InsertRangeAsync(IEnumerable<T> entities);
        void Update(T entity);
        Task UpdateAsync(T entity);
        void Delete(int Id);
        void Delete(T entity);
        Task DeleteAsync(int Id);
        void DeleteRange(IEnumerable<T> entity);
        Task<string> DeleteRangeAsync(IEnumerable<T> entity);
        void Save();
        Task SaveAsync();
    }
}
