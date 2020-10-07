using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModelo.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<T> where T: class
    {
        T Add(T entity);

        T AddAndSave(T entity);

        List<T> AddRange(List<T> entities);

        List<T> AddRangeAndSave(List<T> entities);

        Task<List<T>> AddRangeAndSaveAsync(List<T> entities);

        void Update(T entity);

        Task UpdateAndSaveAsync(T entity);

        Task<T> GetAsync(Expression<Func<T, bool>> expression, bool isNotTracking = false);

        Task<T> GetAsync<k>(Expression<Func<T, bool>> expression, Expression<Func<T, k>> sortExpression, bool orderByDesc = false);

        Task<T> GetByIdAsync(Int64 id);

        T GetByIdResult(Int64 id);

        List<T> GetAll();

        Task<List<T>> GetManyAsunc(Expression<Func<T, bool>> expression);

        List<T> GetMany(Expression<Func<T, bool>> expression);

        Task<List<T>> ExecuteSqlAsync(string query);

        Task<bool> IsExistAsync(Expression<Func<T, bool>> expression);

        void Remove(List<T> entity);

        void Remove(T entity);

        void RemoveAll();
    }
}
