using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using MiBahia_Estate.Services;
using MiBahia_Estate.Solares;
using Microsoft.EntityFrameworkCore;
using MiBahia_Estate.Helpers;
using MiBahia_Estate.Repositories;

using AutoMapper;
using MiBahia_Estate.Models.Properties;
using MiBahia_Estate.Models.Houses;
using MiBahia_Estate.Models.BuildingSites;
using MiBahia_Estate.Models.CoinType;
using MiBahia_Estate.Models.PropertyType;

namespace MiBahia_Estate
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped(typeof(IAsyncRepository<>), typeof(AsyncRepository<>));
            services.AddAutoMapper(configuration =>
            {
                configuration.CreateMap<Property, PropertyDTO>();
                configuration.CreateMap<PropertyITO, Property>().ReverseMap();

                configuration.CreateMap<PropertyAddresses, PropertyAddressesDTO>();
                configuration.CreateMap<PropertyAddressesITO, PropertyAddresses>().ReverseMap();

                configuration.CreateMap<PropertyPhotos, PropertyPhotosDTO>();
                configuration.CreateMap<PropertyPhotosITO, PropertyPhotos>().ReverseMap();

                configuration.CreateMap<PropertyPrice, PropertyPriceDTO>();
                configuration.CreateMap<PropertyPriceITO, PropertyPrice>().ReverseMap();

                configuration.CreateMap<House, HouseDTO>();
                configuration.CreateMap<HouseITO, House>().ReverseMap();

                configuration.CreateMap<BuildingSite, BuildingSiteDTO>();
                configuration.CreateMap<BuildingSiteITO, BuildingSite>().ReverseMap();

                configuration.CreateMap<CoinType, CoinTypeDTO>();
                configuration.CreateMap<CoinTypeITO, CoinType>().ReverseMap();

                configuration.CreateMap<PropertyType, PropertyTypeDTO>();
                configuration.CreateMap<PropertyTypeITO, PropertyType>().ReverseMap();
                
            });
            services.AddDbContext<bahia_estateContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SqlServerconnection")));
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(MyFilter));
            });
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            
        }
    }
}
