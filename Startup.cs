using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApiDepart.Models;

using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace WebApiDepart
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            //services.AddDbContext<DepartmentContext>(op => op.UseSqlServer("Server=NAREN-PC; initial catalog=DepartmentStore;persist security info=True;user id=sa;password=sa123; MultipleActiveResultSets=True;"));
            services.AddControllers();

            //Add framework services
            //services.AddDbContext<DepartmentContext>(options =>
            //     options.UseSqlServer("Server=NAREN-PC;; Database=DepartmentStore1; Trusted_Connection=True; MultipleActiveResultSets=True;"));

            services.AddDbContext<DepartmentContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Register the Swagger services
            services.AddSwaggerDocument();



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});

            // Register the Swagger generator and the Swagger UI middlewares
            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.Use(async (ctx, next) =>
            {
                await next();
                if (ctx.Response.StatusCode == 204)
                {
                    ctx.Response.ContentLength = 0;
                }
            });
        }
    }
}
