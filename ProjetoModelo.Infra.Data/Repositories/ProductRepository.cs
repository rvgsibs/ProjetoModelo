using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using ProjetoModelo.Domain.Entities;
using ProjetoModelo.Domain.Interfaces.Repositories;
using ProjetoModelo.Infra.Data.Context;

namespace ProjetoModelo.Infra.Data.Repositories
{
    public class ProductRepository: RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(ProjetoModeloContext projetoModeloContext): base(projetoModeloContext)
        {

        }
    }
}
