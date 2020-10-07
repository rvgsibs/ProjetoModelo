using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ProjetoModelo.Application.Interfaces;
using ProjetoModelo.Domain.Entities;
using ProjetoModelo.Infra.IoC.ContainerIoc;

namespace ProjetoModelo.API.Controllers
{
    [Authorize]
    [RoutePrefix("api/products")]
    public class ProductController : ApiController
    {
        private readonly IProductApplication _productApplication = SimpleInjectorContainer.Container.GetInstance<IProductApplication>();

        [ResponseType(typeof(List<Product>))]
        [HttpGet]
        [Route("")]
        public async Task<List<Product>> GetProducts()
        {
            var result = await _productApplication.ObterProducts();
            return result;
        }

        [ResponseType(typeof(Product))]
        [HttpGet]
        [Route("{id}")]
        public async Task<Product> GetProducts(long id)
        {
            var result = await _productApplication.ObterProduct(id);
            return result;
        }

        [ResponseType(typeof(void))]
        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> Post(Product product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var productResult = await _productApplication.ObterProduct(product.Id);
            if(productResult != null)
                return BadRequest("Produto já cadastrado");

            _productApplication.Incluir(product);

            return CreatedAtRoute("DefaultApi", new { controller = "products", id = product.Id }, product);
        }

        [HttpPost]
        [Route("name1")]
        public String GetName1()
        {
            if (User.Identity.IsAuthenticated)
            {
                var identity = User.Identity as ClaimsIdentity;
                if (identity != null)
                {
                    IEnumerable<Claim> claims = identity.Claims;
                }
                return "Valid";
            }
            else
            {
                return "Invalid";
            }
        }

        
        [HttpPost]
        [Route("name2")]
        public Object GetName2()
        {
            var identity = User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                IEnumerable<Claim> claims = identity.Claims;
                var name = claims.Where(p => p.Type == "name").FirstOrDefault()?.Value;
                return new
                {
                    data = name
                };

            }
            return null;
        }
    }
}
