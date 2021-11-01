using InventarioAPI.Datos;
using InventarioAPI.InventarioMapper;
using InventarioAPI.Repository;
using InventarioAPI.Repository.IRepository;
using InventarioAPI.Repositorys;
using InventarioAPI.Repositorys.IRepositorys;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioAPI
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
            services.AddDbContext<InventarioContext>(Options => Options.UseSqlServer(Configuration.GetConnectionString("coneccion")));

            services.AddScoped<IEmpresaRepositoy, EmpresaRepository>();
            services.AddScoped<ISucursalRepository, SucursalRepository>();
            services.AddScoped<ITipoArticuloRepository, TipoArticuloRepository>();
            services.AddScoped<IProveedorRepository, ProveedorRepository>();
            services.AddScoped<IArticuloRepository, ArticuloRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IBodegaRepository, BodegaRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ICompraRepository, CompraRepository>(); 

            services.AddAutoMapper(typeof(InventarioMappers));

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
