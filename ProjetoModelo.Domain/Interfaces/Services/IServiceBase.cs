using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModelo.Domain.Interfaces.Services
{
    public interface IServiceBase<T> where T : class
    {
        T Adicionar(T entidade);

        Task<List<T>> AdicionarLista(List<T> entidade);

        T Adicionar(T entidade, string usuario);

        List<T> Adicionar(List<T> entidades);

        List<T> AdicionarSalvar(List<T> entidades);

        void Atualizar(T entidade);

        Task<T> ObterPorIdAsync(Int64 id);

        T ObterPorId(Int64 id);

        Task<List<T>> ObterTodosAsync();

        Task<List<T>> ObterTodosAsync(Expression<Func<T, bool>> query);

        List<T> ObterTodos();

        List<T> ObterTodos(Expression<Func<T, bool>> query);

        Task<T> ObterAsync(Expression<Func<T, bool>> query, bool isNoTracking = false);

        Task<T> ObterAsync<K>(Expression<Func<T, bool>> query, Expression<Func<T, K>> sortExpression, bool orderByDesc = false);

        Task<List<T>> ExecutarSqlAsunc(string query);

        void Remover(T entidade);

        void Remover(List<T> entidade);

        void RemoverTudo();

        Task AtualizarSalvarAsync(T entidade, string usuario = null);
    }
}
