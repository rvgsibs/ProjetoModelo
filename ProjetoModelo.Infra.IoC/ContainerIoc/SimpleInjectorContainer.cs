
using System.Threading;
using ProjetoModelo.Application.ApplicationServices;
using ProjetoModelo.Application.Interfaces;
using ProjetoModelo.Domain.Interfaces.Repositories;
using ProjetoModelo.Domain.Interfaces.Services;
using ProjetoModelo.Domain.Interfaces.UnitOfWork;
using ProjetoModelo.Infra.Data;
using ProjetoModelo.Infra.Data.Context;
using ProjetoModelo.Infra.Data.Repositories;
using ProjetoModelo.Infra.Data.Services;
using SimpleInjector;
using SimpleInjector.Integration.Web;

namespace ProjetoModelo.Infra.IoC.ContainerIoc
{
    public class SimpleInjectorContainer
    {
        public static Container _container;
        private static readonly object s_lock = new object();

        static SimpleInjectorContainer()
        {
            RegisterServices();
        }

        public static Container Container
        {
            get
            {
                if (_container != null) return _container;
                Container temp = RegisterServices();
                Interlocked.Exchange(ref _container, temp);
                return _container;
            }
        }

        public static Container RegisterServices()
        {
            _container = new Container();
            _container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            _container.Register<ProjetoModeloContext>(Lifestyle.Scoped);

            _container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);

            #region Repository
            _container.Register<IProductRepository, ProductRepository>(Lifestyle.Scoped);
            _container.Register<IUsuarioRepository, UsuarioRepository>(Lifestyle.Scoped);
            #endregion

            #region Service
            _container.Register<IProductService, ProductService>(Lifestyle.Scoped);          
            #endregion

            #region Application
            _container.Register<IProductApplication, ProductApplication>(Lifestyle.Scoped);
            #endregion

            return _container;
        }
    }
}
