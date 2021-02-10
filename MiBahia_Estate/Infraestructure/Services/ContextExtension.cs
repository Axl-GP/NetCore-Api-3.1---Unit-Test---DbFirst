using MiBahia_Estate;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Services
{
    public static class ContextExtension
    {
        public static void CustomContextExtension(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<bahia_estateContext>(options => options.UseSqlServer(configuration["DbConnection"]));

        }
    }
}
