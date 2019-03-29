using Apolice.Model.Models;
using Apolice.Repository;
using Apolice.Service;
using SimpleInjector;

namespace Apolice.Ioc
{
    public static class SimpleInjectorContainer
    {
        public static Container RegisterServices()
        {
            var container = new Container();

            //Registrando as Implementações
            container.Register<IDbContext, IocDbContext>(Lifestyle.Singleton);
            container.Register<IApoliceService, ApoliceService>();
            container.Register<IRepository<Model.Models.Apolice>, Repository<Model.Models.Apolice>>();
            container.Register<IApoliceRepository, ApoliceRepository>();

            container.Verify();
            return container;
        }        
    }
}
