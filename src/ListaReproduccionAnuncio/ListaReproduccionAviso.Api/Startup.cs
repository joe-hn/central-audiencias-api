using ListaReproduccionAviso.Infrastructure;
using ListaReproduccionAviso.Service.Proxies;
using ListaReproduccionAviso.Service.Proxies.IProxies;
using ListaReproduccionAviso.Service.Queries.IQueries;
using ListaReproduccionAviso.Service.Queries.Queries;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SEJE.EFCORE.Extensions;
using System;
using System.Reflection;

namespace ListaReproduccionAviso.Api
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

            services.AddCors(opt => 
            {
                opt.AddPolicy("AllowOrigin"
                    , b => b.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod());
            });

            //-- SEJE CONFIGURATION: INICIO ----------------------------------------------------------------
            services.AddAutoMapper(Assembly.Load("ListaReproduccionAviso.Service.Queries"));
            this.AddDbContext(services);
            this.AddSwagger(services);

            services.AddEFCore(this.Configuration)
               .AddIdentityService<string>()
               .AddRepositories<Guid, string, SqlServerContext>();

            services.AddMediatR(Assembly.Load("ListaReproduccionAviso.Service.EventHandler"));

            services.AddTransient<IAvisoQueryService, AvisoQueryService>();

            //Api Urls
            services.Configure<ApiUrl>(opts => Configuration.GetSection("ApiUrl").Bind(opts));

            //Proxies
            services.AddHttpClient<IAnuncioProxy, AnuncioProxy>();

            //-- SEJE CONFIGURATION: FIN ----------------------------------------------------------------
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
            app.UseCors("AllowOrigin");

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ListaReproduccionAviso.Api v1"));

            //app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void AddDbContext(IServiceCollection services)
        {
            var migration = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            services.AddDbContext<SqlServerContext>(options =>
            {
                if (!options.IsConfigured)
                {
                    options.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection"), sqlOptions =>
                    {
                        sqlOptions.MigrationsAssembly(migration);
                        sqlOptions.EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(10), errorNumbersToAdd: null);
                    });
                }
            });

        }

        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                var version = "v1";

                options.SwaggerDoc(version, new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = $".... {version}",
                    Description = "Api de .....",
                    Version = version,
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact()
                    {
                        Name = "SEJE",
                        Email = "seje@seje.gob.hn"
                    }
                }); ;
            });
        }
    }
}
