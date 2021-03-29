using Bytrade.Dominio;
using Bytrade.Repo.Interfaces;
using Bytrade.Repo.Services;
using BytradeApiOff;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Quartz;
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
            

            
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();
            services.AddScoped<IFileGenerationsRepository, FileGenerationsRepository>();
            services.AddScoped<ILogRepository, LogRepository>();

            services.AddScoped<IEntitiesRepository, EntitiesRepository>();
            services.AddScoped<IInventoryItemsRepository, InventoryItemsRepository>();
            services.AddScoped<IInventoryTransactionDocumentsRepository, InventoryTransactionDocumentsRepository>();
            services.AddScoped<IMenuItemPortionsRepository, MenuItemPortionsRepository>();
            services.AddScoped<IMenuItemPricesRepository, MenuItemPricesRepository>();
            services.AddScoped<IInventoryItemsRepository, InventoryItemsRepository>();
            services.AddScoped<IMenuItemsRepository, MenuItemsRepository>();

            List<DayOfWeek> dayOfWeeks = new List<DayOfWeek>();

            dayOfWeeks.Add(DayOfWeek.Monday);
            dayOfWeeks.Add(DayOfWeek.Sunday);
            dayOfWeeks.Add(DayOfWeek.Tuesday);
            dayOfWeeks.Add(DayOfWeek.Wednesday);
            dayOfWeeks.Add(DayOfWeek.Thursday);
            dayOfWeeks.Add(DayOfWeek.Friday);
            dayOfWeeks.Add(DayOfWeek.Saturday);

            var jobKey = new JobKey("Tarefas");
            services.AddQuartz(q =>
            {
                q.SchedulerId = "Tarefas";
                q.SchedulerName = "Tarefas";
                q.UseMicrosoftDependencyInjectionScopedJobFactory();
                q.AddJob<Services>(j => j.WithIdentity(jobKey));
                q.AddTrigger(t => t
                   .WithIdentity("Tarefas")
                   .ForJob(jobKey)
                   .StartNow()
                   .WithSimpleSchedule(x => x
        .WithIntervalInSeconds(30)
        .RepeatForever())
                );
                    // base quartz scheduler, job and trigger configuration
                });



            //    services.AddQuartz(q =>
            //    {
            //        q.SchedulerId = "Tarefas";
            //        q.SchedulerName = "Tarefas";
            //        q.UseMicrosoftDependencyInjectionScopedJobFactory();
            //        q.AddJob<CronLog>(j => j.WithIdentity(jobKey));
            //        q.AddTrigger(t => t
            //           .WithIdentity("Tarefa de log")
            //           .ForJob(jobKey)
            //           .StartNow()
            //           .WithSimpleSchedule(x => x
            //.WithIntervalInSeconds(50)
            //.RepeatForever())
            //        );
            //        // base quartz scheduler, job and trigger configuration
            //    });


            //    // ASP.NET Core hosting
            services.AddQuartzServer(options =>
            {
                    // when shutting down we want jobs to complete gracefully
                    options.WaitForJobsToComplete = true;
            });



            services.AddControllers();
            services.AddSwaggerGen(option => {
                option.SwaggerDoc(
                    "BytradeApi",
                    new Microsoft.OpenApi.Models.OpenApiInfo()
                    {
                        Title = "Bytrade - Api On",
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
