using HelloWorld.Application.Interfaces;
using HelloWorld.Infrastructure.Contexts;
using HelloWorld.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Infrastructure
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<HelloWorldDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("SqlServer")));
            service.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            return service;
        }
    }
}
