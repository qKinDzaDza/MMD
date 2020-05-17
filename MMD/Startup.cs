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
using MMD.Bll;
using MMD.Bll.Services;
using MMD.Dal;
using MMD.Dal.Repositories;
using MMD.Domain.Repositories;
using MMD.Domain.Services;

namespace MMD
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
            services.AddControllers();

            //Services
            services.AddScoped<IAssemblyMmsService, AssemblyMmsService>();
            services.AddScoped<IAccelerometerService, AccelerometerService>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<ICalibrationMmsService, CalibrationMmsService>();
            services.AddScoped<ICalibrationProductService, CalibrationProductService>();
            services.AddScoped<IConfiguringMmsService, ConfiguringMmsService>();
            services.AddScoped<IConfiguringProductService, ConfiguringProductService>();
            services.AddScoped<IConsignmentService, ConsignmentService>();
            services.AddScoped<IGyroscopeService, GyroscopeService>();
            services.AddScoped<IMakeProductService, MakeProductService>();
            services.AddScoped<IMobileTestingMmsService, MobileTestingMmsService>();
            services.AddScoped<IMobileTestingProductService, MobileTestingProductService>();
            services.AddScoped<IPlateService, PlateService>();
            services.AddScoped<IStationaryTestingMmsService, StationaryTestingMmsService>();
            services.AddScoped<IStationaryTestingProductService, StationaryTestingProductService>();
            services.AddScoped<IWarehouseService, WarehouseService>();

            //Repositories
            services.AddScoped<IAssemblyMmsRepository, AssemblyMmsRepository>();
            services.AddScoped<IAccelerometerRepository, AccelerometerRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<ICalibrationMmsRepository, CalibrationMmsRepository>();
            services.AddScoped<ICalibrationProductRepository, CalibrationProductRepository>();
            services.AddScoped<IConfiguringMmsRepository, ConfiguringMmsRepository>();
            services.AddScoped<IConfiguringProductRepository, ConfiguringProductRepository>();
            services.AddScoped<IConsignmentRepository, ConsignmentRepository>();
            services.AddScoped<IGyroscopeRepository, GyroscopeRepository>();
            services.AddScoped<IMakeProductRepository, MakeProductRepository>();
            services.AddScoped<IMobileTestingMmsRepository, MobileTestingMmsRepository>();
            services.AddScoped<IMobileTestingProductRepository, MobileTestingProductRepository>();
            services.AddScoped<IPlateRepository, PlateRepository>();
            services.AddScoped<IStationaryTestingMmsRepository, StationaryTestingMmsRepository>();
            services.AddScoped<IStationaryTestingProductRepository, StationaryTestingProductRepository>();
            services.AddScoped<IWarehouseRepository, WarehouseRepository>();

            services.AddScoped<ApplicationContext>();
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
