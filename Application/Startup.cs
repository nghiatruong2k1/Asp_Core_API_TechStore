using Application.Contexts;
using Application.Helper;
using Application.Interface;
using Application.Models;
using Application.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_NET_CORE_API_TTTN
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
            IdentityModelEventSource.ShowPII = true;

            services.AddDistributedMemoryCache();
            services.AddSession();
            //Enable CORS
            services.AddCors(options=> {
                options.AddDefaultPolicy(
                    policy =>
                    {
                        policy.AllowAnyMethod()
                              .AllowAnyHeader()
                              .SetIsOriginAllowed(origin => true)
                              .AllowCredentials();
                    });
            });

            services.AddTransient<IEmailService, EmailService>();
            services.Configure<EmailConfigs>(Configuration.GetSection("EmailConfigs"));
            services.AddDbContext<TechStoreContext>(item => 
                item.UseNpgsql(Environment.GetEnvironmentVariable("ASPNETCORE_CONNECTION_STR"))
            );
            services.AddControllers();
               //.ConfigureApiBehaviorOptions(options =>
               // {
               //     options.SuppressConsumesConstraintForFormFileParameters = true;
               //     options.SuppressInferBindingSourcesForParameters = true;
               //     options.SuppressModelStateInvalidFilter = true;
               //     options.SuppressMapClientErrors = true;
               //     options.ClientErrorMapping[StatusCodes.Status404NotFound].Link =
               //         "https://httpstatuses.com/404";
               // });
            services.AddScoped<JwtService>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
            });

            //JSON Serializer
            services.AddControllersWithViews().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
                .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver
                = new DefaultContractResolver());

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ASP_NET_CORE_API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseSession();
            app.UseCookiePolicy();

            app.UseAuthorization();

            app.UseForwardedHeaders();


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ASP_NET_CORE_API v1"));
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();


            //Enable CORS
            app.UseCors();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                   name: "admin",
                   pattern: "{area:exists}/{controller}/{action}/{id?}"
                );
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" }
                );
            });

        }
    }
}
