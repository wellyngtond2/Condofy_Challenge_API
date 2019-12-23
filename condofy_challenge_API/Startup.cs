using condofy_challenge_API.App.App;
using condofy_challenge_API.App.Interfaces;
using condofy_challenge_API.Domain.Interfaces.Config;
using condofy_challenge_API.Domain.Interfaces.Repositories;
using condofy_challenge_API.Domain.Interfaces.Services;
using condofy_challenge_API.Domain.Services;
using condofy_challenge_API.Infra.Config;
using condofy_challenge_API.Infra.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace condofy_challenge_API
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);


            services.AddSingleton<IConfiguration>(Configuration);
            services.AddTransient<IFuncionarioService, FuncionarioService>();
            services.AddTransient<IDBConfig, DBConfig>();
            services.AddTransient<IFuncionarioRepository, FuncionarioRepository>();
            services.AddTransient<IFileRepository, FileRepository>();
            services.AddTransient<IFuncionarioApp, FuncionarioApp>();

            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo() { Title = "Condofy API", Version = "v1" }); });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseStaticFiles();

            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Funcionario"); });
        }
    }
}
