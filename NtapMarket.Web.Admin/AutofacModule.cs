using Autofac;
using Microsoft.Extensions.Configuration;
using NtapMarket.Data.EF.Repository;
using NtapMarket.Data.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace NtapMarket.Web.Admin
{
    public static class AutofacModule
    {
        public static ContainerBuilder GetContainerBuilder(IConfiguration configuration)
        {
            var builder = new ContainerBuilder();

            string connectionString = configuration.GetConnectionString("NtapMarket");
            var repository = new ProductModelRepository(connectionString);

            builder.Register(x => repository).As<IProductModelRepository>();
            return builder;
        }
    }
}
