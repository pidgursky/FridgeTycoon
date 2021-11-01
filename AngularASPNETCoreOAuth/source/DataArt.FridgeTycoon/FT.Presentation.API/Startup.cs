using System.Reflection;
using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FT.Persistence;
using FT.Infrastructure;
using FT.Queries.Productor.Get;
using FT.Commands.Products.Create;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Hosting;
using System.Security.Claims;
using Swashbuckle.AspNetCore.SwaggerUI;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FT.Domain.Entities.Users;
using FT.Domain.Entities;
using FT.Domain.Entities.FridgeAggregate;
using FT.Domain.Entities.ProductAggregate;
using FT.Services.UserClaimService;
using NLog;
using System.IO;
using FluentValidation.AspNetCore;



namespace FT.Presentation.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<FTDBContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Description = "Demo Swagger API v1",
                    Title = "Swagger with ID4",
                    Version = "1.0.0"
                });
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        Password = new OpenApiOAuthFlow
                        {
                            TokenUrl = new Uri("http://localhost:5000"),
                            Scopes = new Dictionary<string, string>
                            {
                                {"SwaggerAPI", "Swagger API Demo"}
                            }
                        }
                    }
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "oauth2"

                            },
                            Scheme = "oauth2",
                            Name = "Barer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });

            });

            //TODO: move URL to appsetings.json
            services.AddControllersWithViews();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.Authority = "http://localhost:5000";
                o.Audience = "resourceapi";
                o.RequireHttpsMetadata = false;
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("ApiReader", policy => policy.RequireClaim("scope", "api.read"));
                options.AddPolicy("Consumer", policy => policy.RequireClaim(ClaimTypes.Role, "consumer"));
                options.AddPolicy("Admin", policy => policy.RequireClaim(ClaimTypes.Role, "admin"));
            });

            services
                .AddMvc(options => { options.EnableEndpointRouting = false; })
                .AddFluentValidation(options =>
                {
                    options.RegisterValidatorsFromAssembly(Assembly.Load("FT.Infrastructure"));
                })
                .SetCompatibilityVersion(CompatibilityVersion.Latest);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddMediatR(typeof(GetProductQueryHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(CreateObjectItemCommandHandler).GetTypeInfo().Assembly);

            services.AddTransient<IFridgeRepository, FridgeRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IProductRepository,ProductRepository>();
            services.AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddTransient(typeof(IUserClaimService), typeof(UserClaimService));
            services.AddHttpContextAccessor();

            services.AddDbContext<FTDBContext>();

        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(options => options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            app.UseAuthentication();
            app.UseAuthorization();


            app.UseMvc();
            app.UseStaticFiles();


            app.UseSwagger();
            app.UseSwaggerUI(options=>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger UI Demo");
                options.DocumentTitle = "Title";
                options.RoutePrefix = "docs";
                options.DocExpansion(DocExpansion.List);
                options.OAuthClientId("client_id_swagger");
                options.OAuthClientSecret("client_secret_swagger");

            });

            app.UseMvc();
        }
    }
}
