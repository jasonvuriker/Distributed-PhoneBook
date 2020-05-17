using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PhoneBook.API.Queries;
using PhoneBook.API.Repositories;
using PhoneBook.Common.Db;
using PhoneBook.Common.Dispatchers;
using PhoneBook.Common.Filters;
using PhoneBook.Common.Mvc;
using PhoneBook.Common.Swagger;
using PhoneBook.Common.Types;

namespace PhoneBook.API
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
            services.AddSql()
                .AddRepositories()
                .AddHandlers()
                .AddDispatchers()
                .AddSwagger();

            services.AddScoped<IPhoneBookRepository, PhoneBookRepository>();

            services.AddCors();

            services.AddAutoMapper(typeof(MappingProfile));

            // services.AddControllers();

            services.AddControllers(options => options.Filters.Add(new ModelValidationFilter()))
                .ConfigureApiBehaviorOptions(c => c.SuppressModelStateInvalidFilter = true);
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

            app.UseErrorHandler();

            app.UseCors(c => c
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod()
            );

            app.UseAuthorization();

            app.UseSwagger();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
