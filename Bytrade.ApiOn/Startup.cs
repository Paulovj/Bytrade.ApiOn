using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
namespace Bytrade.ApiOn
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
            services.AddDbContext<ByTradeGeralAppContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnetions"));
            });

            services.AddControllers();
            services.AddSwaggerGen(option => {
                option.SwaggerDoc(
                    "BytradeApi",
                    new Microsoft.OpenApi.Models.OpenApiInfo()
                    {
                        Title = "Bytrade Api",
                        Version = "1.0"

                    }
                );
                var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);

                option.IncludeXmlComments(xmlCommentsFullPath);

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseSwagger()
                .UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("swagger/BytradeApi/swagger.json", "BytradeApi");
                    options.RoutePrefix = "";
                });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
