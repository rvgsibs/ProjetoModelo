using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ProjetoModelo.Domain.Interfaces.Repositories;
using ProjetoModelo.Infra.Data.Context;

namespace ProjetoModelo.Infra.Data.Repositories
{
    public class RepositoryBase<T> :IRepositoryBase<T> where T: class
    {
        public ProjetoModeloContext _projetoModeloContext;

        public RepositoryBase(ProjetoModeloContext projetoModeloContext)
        {
            _projetoModeloContext = projetoModeloContext;
        }

        public T Add(T entity)
        {
            var result = _projetoModeloContext.Set<T>().Add(entity);            
            return result;
        }

        public T AddAndSave(T entity)
        {
            var result = _projetoModeloContext.Set<T>().Add(entity);
            _projetoModeloContext.SaveChanges();
            return result;
        }

        public List<T> AddRange(List<T> entities)
        {
            return _projetoModeloContext.Set<T>().AddRange(entities).ToList();
        }

        public List<T> AddRangeAndSave(List<T> entities)
        {
            var result = _projetoModeloContext.Set<T>().AddRange(entities).ToList();
            _projetoModeloContext.SaveChanges();
            return result;
        }

        public async Task<List<T>> AddRangeAndSaveAsync(List<T> entities)
        {
            var result = _projetoModeloContext.Set<T>().AddRange(entities).ToList();
            _projetoModeloContext.SaveChanges();
            return result;
        }

        public Task<List<T>> ExecuteSqlAsync(string query)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> expression, bool isNotTracking = false)
        {
            if (!isNotTracking)
            {
                return  _projetoModeloContext.Set<T>().Where(expression).FirstOrDefault();
            }
            else
            {
                return  _projetoModeloContext.Set<T>().AsNoTracking().Where(expression).FirstOrDefault();
            }
           
        }

        public async Task<T> GetAsync<k>(Expression<Func<T, bool>> expression, Expression<Func<T, k>> sortExpression, bool orderByDesc = false)
        {
            return !orderByDesc ?  _projetoModeloContext.Set<T>().Where(expression).OrderBy(sortExpression).FirstOrDefault() :
                 _projetoModeloContext.Set<T>().Where(expression).OrderByDescending(sortExpression).FirstOrDefault();
               
        }

        public async Task<List<T>> GetAllAsync()
        {
            return _projetoModeloContext.Set<T>().ToList();
        }

        public List<T> GetAll()
        {
            return _projetoModeloContext.Set<T>().ToList();
        }

        public Task<T> GetByIdAsync(long id)
        {
            return _projetoModeloContext.Set<T>().FindAsync(id);
        }

        public T GetByIdResult(long id)
        {
            return _projetoModeloContext.Set<T>().FindAsync(id).Result;
        }

        public List<T> GetMany(Expression<Func<T, bool>> expression)
        {
            return _projetoModeloContext.Set<T>().Where(expression).ToList();
        }

        public async Task<List<T>> GetManyAsunc(Expression<Func<T, bool>> expression)
        {
            return _projetoModeloContext.Set<T>().Where(expression).ToList();
        }

        public async Task<bool> IsExistAsync(Expression<Func<T, bool>> expression)
        {
            return await GetAsync(expression, true) != null;
        }

        public void Remove(List<T> entity)
        {
            _projetoModeloContext.Set<T>().RemoveRange(entity);
        }

        public void Remove(T entity)
        {
            _projetoModeloContext.Set<T>().Remove(entity);
        }

        public void RemoveAll()
        {

            string nomeTabela = typeof(T).GetCustomAttributesData().Count == 0 ? null :
                (typeof(T).GetCustomAttributesData()[0].ConstructorArguments.Count == 0 ? null : typeof(T).GetCustomAttributesData()[0].ConstructorArguments[0].Value.ToString());

            if (string.IsNullOrEmpty(nomeTabela))
                throw new Exception("Nome da tabela não preenchida");

            _projetoModeloContext.Database.ExecuteSqlCommand($"DELETE FROM {nomeTabela}");
            _projetoModeloContext.SaveChanges();
        }

        public void Update(T entity)
        {
            //_projetoModeloContext.Set<T>().Update(entity);
        }

        public async Task UpdateAndSaveAsync(T entity)
        {
            _projetoModeloContext.Set<T>().Add(entity);
            await _projetoModeloContext.SaveChangesAsync();
        }

        public void Dispse()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if(_projetoModeloContext != null)
                {
                    _projetoModeloContext.Dispose();
                    _projetoModeloContext = null;
                }
            }
        }
    }
}
