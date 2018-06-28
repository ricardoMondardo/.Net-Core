using Swashbuckle.AspNetCore.Swagger;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Repository;
using WebApi.Services;

namespace WebApi
{
    public class Startup
    {

        private IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<DataBaseContext>(options =>
                options.UseSqlite(_configuration.GetConnectionString("DefaultConnection")));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info {
                    Title = "My API",
                    Version = "v1",
                    Description = "In progress",
                    Contact = new Contact
                    {
                        Name = "Ricardo Brina Mondardo",
                        Email = "ricardo9300@gmail.com"
                    }
                });
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IProductService, ProductService>();

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();


            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseMvc();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("MVC could not found anything!");
            });
        }
    }
}
