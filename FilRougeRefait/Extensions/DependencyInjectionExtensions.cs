using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using CoVoyageur.Core.Models;
using CoVoyageur.API.Helpers;
using CoVoyageur.API.Repositories;
using System.Security.Claims;
using System.Text;
using System.Text.Json.Serialization;
using CoVoyageur.API.Data;

namespace CoVoyageur.API.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static void InjectDependancies(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers().AddJsonOptions(x =>
                            x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            builder.AddSwagger();

            builder.AddDatabase();

            //builder.AddRepositories();

            builder.AddAuthentication();

            builder.AddAuthorization();
        }

        private static void AddSwagger(this WebApplicationBuilder builder)
        {

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CoVoyageurAPI", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme.",
                    Name = "Authorization",
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    Type = SecuritySchemeType.Http
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme
                        {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                        },
                        new string[] { }
                    }
                });
            });
        }

        private static void AddDatabase(this WebApplicationBuilder builder)
        {
            string connectionString = builder.Configuration.GetConnectionString("FilRougeRefaitContext")!;
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
        }

        //private static void AddRepositories(this WebApplicationBuilder builder)
        //{
        //    builder.Services.AddScoped<IRepository<Feedback>, FeedbackRepository>();
        //    builder.Services.AddScoped<IRepository<Reservation>, ReservationRepository>();
        //    builder.Services.AddScoped<IRepository<Ride>, RideRepository>();
        //    builder.Services.AddScoped<IRepository<User>, UserRepository>();
        //}

        private static void AddAuthentication(this WebApplicationBuilder builder)
        {
            var appSettingsSection = builder.Configuration.GetSection(nameof(AppSettings));
            builder.Services.Configure<AppSettings>(appSettingsSection); 
            AppSettings appSettings = appSettingsSection.Get<AppSettings>();

            var key = Encoding.ASCII.GetBytes(appSettings.SecretKey!);

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuerSigningKey = true, 
                        IssuerSigningKey = new SymmetricSecurityKey(key), 
                        ValidateLifetime = true, 
                        ValidateAudience = true, 
                        ValidAudience = appSettings.ValidAudience, 
                        ValidateIssuer = true,
                        ValidIssuer = appSettings.ValidIssuer, 
                        ClockSkew = TimeSpan.Zero 
                    };
                });
        }
        private static void AddAuthorization(this WebApplicationBuilder builder)
        {
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy(Constantes.PolicyAdmin, police =>
                {
                    police.RequireClaim(ClaimTypes.Role, Constantes.RoleAdmin);
                });
                options.AddPolicy(Constantes.PolicyUser, police =>
                {
                    police.RequireClaim(ClaimTypes.Role, Constantes.RoleUser);
                });
            });
        }
    }
}
