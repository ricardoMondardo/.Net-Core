using AspNetCore.IServiceCollection.AddIUrlHelper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using Web.EmailSender.Interfaces;
using Web.EmailSender.Services;
using Web.Repository.Context;
using Web.Repository.Interfaces;
using Web.Api.Repository.Implementations;
using Web.Api.Services;

namespace Web.Api
{
    public class Startup
    {

        private readonly IHostingEnvironment Env;

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            Env = env;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {

            if (Env.IsDevelopment())
            {
                services.AddDbContext<DataBaseContext>(options =>
                options.UseInMemoryDatabase("foo"));
            }
            else
            {
                services.AddDbContext<DataBaseContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ProdConnection")));
            }

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IProductService, ProductService>();

            services.AddSingleton<IEmailConfiguration>(Configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>());
            services.AddTransient<IEmailService, EmailService>();

            services.AddUrlHelper();

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.ContractResolver =
                        new CamelCasePropertyNamesContractResolver();
                });
        }

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

            app.UseStaticFiles();
            app.UseMvc();

        }
    }
}
