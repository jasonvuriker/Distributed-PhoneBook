using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NSwag.Generation.Processors.Security;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Common.Swagger
{
    public static class Extensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            SwaggerOptions options;
            using (var serviceProvider = services.BuildServiceProvider())
            {
                var configuration = serviceProvider.GetService<IConfiguration>();
                options = configuration.GetOptions<SwaggerOptions>("swagger");
            }

            if (options == default)
                return services;

            if (!options.Enabled)
                return services;

            services.AddOpenApiDocument(conf =>
            {
                conf.PostProcess = e =>
                {
                    e.Info.Title = options.Title;
                    e.Info.Version = options.Version;

                };

                if (options.IncludeSecurity)
                {
                    conf.AddSecurity("Bearer", new NSwag.OpenApiSecurityScheme
                    {
                        Description = "Jwt Auth",
                        Name = "Authorization",
                        In = NSwag.OpenApiSecurityApiKeyLocation.Header,
                        Type = NSwag.OpenApiSecuritySchemeType.ApiKey
                    });
                    conf.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("bearer"));
                }
            });

            return services;
        }

        public static IApplicationBuilder UseSwagger(this IApplicationBuilder builder)
        {
            var options = builder.ApplicationServices.GetService<IConfiguration>()
                .GetOptions<SwaggerOptions>("swagger");
            if (!options.Enabled)
                return builder;

            // add some configurations 

            builder.UseOpenApi();
            builder.UseSwaggerUi3();
            return builder;
        }
    }
}
