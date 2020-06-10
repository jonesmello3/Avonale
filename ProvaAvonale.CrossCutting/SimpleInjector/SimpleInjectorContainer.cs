using ProvaAvonale.Anticorruption.Interfaces;
using ProvaAvonale.Anticorruption.Services;
using ProvaAvonale.ApplicationService.Applications;
using ProvaAvonale.ApplicationService.Interfaces;
using ProvaAvonale.DataAccess.Repository;
using ProvaAvonale.Domain.Interfaces.Repository;
using ProvaAvonale.Domain.Interfaces.Service;
using ProvaAvonale.Domain.Services;
using SimpleInjector;

namespace ProvaAvonale.CrossCutting.SimpleInjector
{
    public class SimpleInjectorContainer
    {
        #region Register
        public static void Register(Container container)
        {
            RegisterApllicationService(container);
            RegisterService(container);
            RegisterRepository(container);
        }
        #endregion

        #region RegisterApllicationService
        private static void RegisterApllicationService(Container container)
        {
            container.Register(typeof(IApplicationServiceBase<>), typeof(ApplicationServiceBase<>).Assembly);
            container.Register<IRepositorioApplicationService, RepositorioApplicationService>(Lifestyle.Singleton);
        }
        #endregion

        #region RegisterService
        private static void RegisterService(Container container)
        {
            container.Register(typeof(IServiceBase<>), typeof(ServiceBase<>).Assembly);
            container.Register<IRepositorioService, RepositorioService>(Lifestyle.Singleton);
            container.Register<IGitHubService, GitHubService>(Lifestyle.Singleton);
        }
        #endregion

        #region RegisterRepository
        private static void RegisterRepository(Container container)
        {
            container.Register(typeof(IRepositoryBase<>), typeof(RepositoryBase<>).Assembly);
            container.Register<IRepositorioRepository, RepositorioRepository>(Lifestyle.Singleton);
        }
        #endregion
    }
}
