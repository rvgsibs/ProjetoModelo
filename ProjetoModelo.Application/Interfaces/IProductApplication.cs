using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ProjetoModelo.Domain.Entities;

namespace ProjetoModelo.Application.Interfaces
{
    public interface IProductApplication: IApplicationBase
    {
        Task<List<Product>> ObterProducts();

        Task<Product> ObterProduct(long id);

        long Incluir(Product product);
     }
}
