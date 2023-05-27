using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PruebaTecnica.Application.Contracts.Persistence;
using PruebaTecnica.Infrastructura.Repositories;
using PruebaTecnica.Infrastructure;
using PruebaTecnica.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Infrastructura
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

           
            services.AddDbContext<PruebaTecnicaContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ConnectionString"))
            );
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
       


           

            return services;
        }
    }
}
