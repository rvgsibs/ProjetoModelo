using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ProjetoModelo.Application.Interfaces;
using ProjetoModelo.Domain.Entities;
using ProjetoModelo.Domain.Interfaces.Services;

namespace ProjetoModelo.Application.ApplicationServices
{
    public class ProductApplication: ApplicationBase, IProductApplication
    {
        private readonly IProductService _productService;

        public ProductApplication(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<List<Product>> ObterProducts()
        {
            return _productService.ObterTodos();
        }

        public async Task<Product> ObterProduct(long id)
        {
            return await _productService.ObterPorIdAsync(id);
        }

        public long Incluir(Product product)
        {
            var retorno = _productService.Adicionar(product);
            return retorno.Id;
        }
    }
}
