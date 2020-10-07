using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ProjetoModelo.Domain.Interfaces.Repositories;
using ProjetoModelo.Domain.Interfaces.Services;

namespace ProjetoModelo.Infra.Data.Services
{
    public class ServiceBase<T> : IServiceBase<T> where T : class
    {

        private readonly IRepositoryBase<T> _repository;

        public ServiceBase(IRepositoryBase<T> repository)
        {
            _repository = repository;
        }

        public T Adicionar(T entidade)
        {
            return _repository.Add(entidade);
        }

        public T Adicionar(T entidade, string usuario)
        {
            return _repository.Add(entidade);
        }

        public List<T> Adicionar(List<T> entidades)
        {
            return _repository.AddRange(entidades);
        }

        public async Task<List<T>> AdicionarLista(List<T> entidade)
        {
            return await _repository.AddRangeAndSaveAsync(entidade);
        }

        public List<T> AdicionarSalvar(List<T> entidades)
        {
            return _repository.AddRangeAndSave(entidades);
        }

        public void Atualizar(T entidade)
        {
            _repository.Update(entidade);
        }

        public async Task AtualizarSalvarAsync(T entidade, string usuario = null)
        {
            await _repository.UpdateAndSaveAsync(entidade);
        }

        public async Task<List<T>> ExecutarSqlAsunc(string query)
        {
            return await _repository.ExecuteSqlAsync(query);
        }

        public async Task<T> ObterAsync(Expression<Func<T, bool>> query, bool isNoTracking = false)
        {
            return await _repository.GetAsync(query, isNoTracking);
        }

        public async Task<T> ObterAsync<K>(Expression<Func<T, bool>> query, Expression<Func<T, K>> sortExpression, bool orderByDesc = false)
        {
            return await _repository.GetAsync(query, sortExpression, orderByDesc);
        }

        public  T ObterPorId(long id)
        {
            return _repository.GetByIdResult(id);
        }

        public async Task<T> ObterPorIdAsync(long id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public List<T> ObterTodos()
        {
            return  _repository.GetAll();
        }

        public List<T> ObterTodos(Expression<Func<T, bool>> query)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> ObterTodosAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> ObterTodosAsync(Expression<Func<T, bool>> query)
        {
            throw new NotImplementedException();
        }

        public void Remover(T entidade)
        {
            _repository.Remove(entidade);
        }

        public void Remover(List<T> entidade)
        {
            _repository.Remove(entidade);
        }

        public void RemoverTudo()
        {
            _repository.RemoveAll();
        }
    }
}
