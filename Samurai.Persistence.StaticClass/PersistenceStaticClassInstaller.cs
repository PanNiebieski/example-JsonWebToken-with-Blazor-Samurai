using Microsoft.Extensions.DependencyInjection;
using Samurai.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samurai.Infrastructur.Persistence.StaticClass
{
    public static class PersistenceStaticClassInstaller
    {
        public static IServiceCollection AddPersistenceServices
            (this IServiceCollection services)
        {

            services.AddScoped<ISamuraiWarriorRepository, SamuraiWarriorRepository>();

            return services;
        }
    }
}
