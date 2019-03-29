using Apolice.Model.Models;
using Apolice.Repository;
using Apolice.Service;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apolice.Test
{
    class Program
    {
        static readonly Container container;

        static Program()
        {
            container = new Container();

            container.Register<IDbContext, IocDbContext>(Lifestyle.Singleton);
            container.Register<IApoliceService, ApoliceService>();
            container.Register<IRepository<Model.Models.Apolice>, Repository<Model.Models.Apolice>>();


            container.Verify();
        }

        static void Main(string[] args)
        {
            var service = container.GetInstance<IApoliceService>();
            Console.WriteLine(service.GetApolices());
            Console.ReadLine();
        }
    }
}
