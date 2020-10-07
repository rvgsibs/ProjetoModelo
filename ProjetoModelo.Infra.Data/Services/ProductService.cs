using System;
using System.Collections.Generic;
using System.Text;
using ProjetoModelo.Domain.Entities;
using ProjetoModelo.Domain.Interfaces.Repositories;
using ProjetoModelo.Domain.Interfaces.Services;
using ProjetoModelo.Domain.Interfaces.UnitOfWork;

namespace ProjetoModelo.Infra.Data.Services
{
    public class ProductService: ServiceBase<Product>, IProductService
    {
        private readonly IProductRepository _productRepositoty;
        private readonly IUnitOfWork _unitOfWork ;

        public ProductService(IUnitOfWork unitOfWork, IProductRepository productRepositoty): base(productRepositoty)
        {
            _productRepositoty = productRepositoty;
            _unitOfWork = unitOfWork;

        }

    }
}
