using Application.IdentityEntities;
using Application.Repositories;
using Application.Repositories.Common;
using Infrastructure.ImpRepositories.Common;
using Infrastructure.ImpRepositories.Setup;
using Infrastructure.ImpServices.Setup;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCore.AutoRegisterDi;
using System.Reflection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HRMDbContext>(options =>
           options.UseSqlServer(
               configuration.GetConnectionString("HRMDbConnection"),
               b => b.MigrationsAssembly(typeof(HRMDbContext).Assembly.FullName)));

            //services.AddDbContext<HRMDbContext>(options =>
            //{
            //    options.UseSqlServer(configuration.GetConnectionString("HRMDbConnection"));
            //    options.EnableSensitiveDataLogging();
            //});

            services.AddScoped<IHRMDbContext>(provider => provider.GetService<HRMDbContext>());

            services.AddIdentity<ApplicationUser, ApplicationRole>(
                options => options.SignIn.RequireConfirmedEmail = false)
                .AddEntityFrameworkStores<HRMDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 4;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";

                options.User.RequireUniqueEmail = false;
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

            });
      


            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            Dependency(services, configuration);




            return services;

            #region Default
            //services.Configure<JWTSettings>(configuration.GetSection("JWTSettings"));
            //services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //    .AddJwtBearer(o =>
            //    {
            //        o.RequireHttpsMetadata = false;
            //        o.SaveToken = false;
            //        o.TokenValidationParameters = new TokenValidationParameters
            //        {
            //            ValidateIssuerSigningKey = true,
            //            ValidateIssuer = true,
            //            ValidateAudience = true,
            //            ValidateLifetime = true,
            //            ClockSkew = TimeSpan.Zero,
            //            ValidIssuer = configuration["JWTSettings:Issuer"],
            //            ValidAudience = configuration["JWTSettings:Audience"],
            //            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWTSettings:Key"]))
            //        };
            //        o.Events = new JwtBearerEvents()
            //        {
            //            OnAuthenticationFailed = c =>
            //            {
            //                c.NoResult();
            //                c.Response.StatusCode = 500;
            //                c.Response.ContentType = "text/plain";
            //                return c.Response.WriteAsync(c.Exception.ToString());
            //            },
            //            OnChallenge = context =>
            //            {
            //                context.HandleResponse();
            //                context.Response.StatusCode = 401;
            //                context.Response.ContentType = "application/json";
            //                var result = JsonConvert.SerializeObject(new Response<string>("You are not Authorized"));
            //                return context.Response.WriteAsync(result);
            //            },
            //            OnForbidden = context =>
            //            {
            //                context.Response.StatusCode = 403;
            //                context.Response.ContentType = "application/json";
            //                var result = JsonConvert.SerializeObject(new Response<string>("You are not authorized to access this resource"));
            //                return context.Response.WriteAsync(result);
            //            },
            //        };
            //    });
            #endregion Default
        }
        public static void Dependency(this IServiceCollection services, IConfiguration configuration)
        {


            #region Assembly Repository
            var assembliesToScan = new[]
                   {
                        Assembly.GetExecutingAssembly(),
                               Assembly.GetAssembly(typeof(CompanyInfoRepository)),
                        Assembly.GetAssembly(typeof(CompanyInfoService)),

                   };

            //This registers the service layer: I only register the classes who name ends with "Service"(at the moment)

            services.RegisterAssemblyPublicNonGenericClasses(assembliesToScan)
                .Where(s => s.Name.EndsWith("Repository")
                         || s.Name.EndsWith("Service"))
                .AsPublicImplementedInterfaces();

            #endregion Assembly Repository

        }
    }
}
