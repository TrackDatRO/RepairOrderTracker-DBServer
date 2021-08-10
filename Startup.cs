using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using RepairOrderTrakerAPI.Services;
using RepairOrderTrakerAPI.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepairOrderTrakerAPI
{
   public class Startup
   {
      public Startup(IConfiguration configuration) => Configuration = configuration;

      public IConfiguration Configuration { get; }

      // This method gets called by the runtime. Use this method to add services to the container.
      public void ConfigureServices(IServiceCollection services)
      {
         services.Configure<MongoDatabaseSettings>(Configuration.GetSection(nameof(MongoDatabaseSettings)));

         services.AddSingleton<IMongoDatabaseSettings>(sp => sp.GetRequiredService<IOptions<MongoDatabaseSettings>>().Value);

         // Add database services here...
         services.AddSingleton<JobService>();
         services.AddSingleton<PayPeriodService>();
         services.AddSingleton<RepairOrderService>();
         services.AddSingleton<TechService>();
         services.AddSingleton<UserService>();

         services.AddControllers().AddNewtonsoftJson(opt => opt.UseMemberCasing());
         services.AddSwaggerGen(c =>
         {
            c.SwaggerDoc(
               "v1",
               new OpenApiInfo
               { 
                  Title = "RepairOrderTrackerAPI",
                  Version = "v1",
                  Description = "API for repair order tracker app."
               }
            );
         });
      }

      // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
      public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
      {
         if (env.IsDevelopment())
         {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RepairOrderTrakerAPI v1"));
         }

         app.UseHttpsRedirection();

         app.UseRouting();

         app.UseAuthorization();

         app.UseEndpoints(endpoints => endpoints.MapControllers());
      }
   }
}
