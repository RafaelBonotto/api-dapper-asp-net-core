using Comercio.Data.ConnectionManager;
using Comercio.Data.Repository;
using Comercio.Domain.Interfaces;
using Comercio.Domain.Services;
using Comercio.Services.Interfaces;
using Comercio.Services.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace Comercio.API
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

            services
            .AddControllers()
            .ConfigureApiBehaviorOptions(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Comercio.API", Version = "v1" });
            });

            var key = Encoding.ASCII.GetBytes(Configurationn.JwtKey);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme =  JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            #region Injeção de dependência

            // Services:
            services.AddTransient<TokenService>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<ISetorService, SetorService>();
            services.AddScoped<IUsuarioService, UsuarioService>();

            // Repositorys:
            services.AddScoped<IMySqlConnectionManager, MySqlConnectionManager>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<ISetorRepository, SetorRepository>();

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Comercio.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
