using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MyProj.CM.API.Authentication;
using MyProj.CM.API.Configurations;
using MyProj.CM.API.Middleware;
using MyProj.CM.Common.Caching;
using MyProj.CM.Common.Security.Jwt;
using MyProj.CM.Apps.Common;
using Microsoft.AspNetCore.Http;
using MyProj.CM.Apps.Common.Extensions;

namespace MyProj.CM.API
{
    public class Startup
    {
        private const string CorsPolicyName = "EnableUiCorsOnDevOnly";
        public IConfiguration Configuration { get; }
        private readonly IWebHostEnvironment _environment;
        public Startup(IConfiguration configuration,IWebHostEnvironment env)
        {
            Configuration = configuration;
            _environment = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            if (_environment.IsDevelopment())
            {
                services.AddAuthProxyMoq(Configuration.GetSection(nameof(AuthProxyMoqMiddleware)));
                services.AddCors(
                    options => options.AddPolicy(
                        CorsPolicyName,
                        builder =>
                        {
                            builder.WithOrigins(Configuration["WebAppUrl"]);
                            builder.AllowCredentials();
                            builder.AllowAnyMethod();
                            builder.AllowAnyHeader();
                            builder.WithExposedHeaders("Content-Disposition");
                        }
                        ));
            }

            services.UseGrpcClient(Configuration);
            services.UseMemoryCache();
            services.AddAuthentication(AuthProxyAuthenticationHandler.AuthProxyScheme)
                .AddScheme<AuthenticationSchemeOptions, AuthProxyAuthenticationHandler>(AuthProxyAuthenticationHandler.AuthProxyScheme, null);

            services.AddControllers().AddNewtonsoftJson();

            var jwtToekn = new JwtToken();
            Configuration.Bind("jwtToken", jwtToekn);
            var jwtService = new JwtTokenService(new JwtConfig(jwtToekn.Audience, jwtToekn.Issuer, jwtToekn.PrivateKey, jwtToekn.TimeInSeconds));
            services.AddSingleton<IJwtTokenService>(jwtService);

            services.AddSingleton(typeof(IConfiguration), Configuration);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient(provider => provider.GetService<IHttpContextAccessor>().HttpContext?.User?.GetUserPrincipal());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseAuthProxyMoq();
                app.UseDeveloperExceptionPage();
                app.UseCors(CorsPolicyName);
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
