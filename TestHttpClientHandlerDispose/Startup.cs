using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using TestHttpClientHandlerDispose.Extensions;
using TestHttpClientHandlerDispose.Handlers;
using TestHttpClientHandlerDispose.Services;

namespace TestHttpClientHandlerDispose
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddTransient<ValidateHeaderHandler>();
            services.AddHttpClient<IRepoService, RepoService>(
                c =>
                {
                    c.BaseAddress = new Uri("https://api.github.com/");
                    c.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
                    c.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample");
                })
                .AddHttpMessageHandler<ValidateHeaderHandler>();

            if (false)
            {
                return services.UseAutofac();
            }
            else
            {
                return services.UseWindsor();
            }
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
