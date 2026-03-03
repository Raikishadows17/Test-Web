using Application.Interface.Context;
using Application.Interface.Repository;
using Application.Interface.Repository.Entities;
using Application.Interface.Service;
using Application.Mappings;
using Application.Services;
using Domain.Common;
using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.DataContext;
using Infrastructure.Factories;
using Infrastructure.Repositories.Entities;
using Infrastructure.Security;
using Mapster;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Middleware;
using Scalar.AspNetCore;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using TLSRestApi.Attributes;
using TLSRestApi.Middleware;

namespace TLSRestApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            ConfigureControllers(builder.Services);
            ConfigureCors(builder.Services, builder.Configuration);
            ConfigureAuthentication(builder.Services, builder.Configuration);
            ConfigureAuthorization(builder.Services);
            ConfigureMapping(builder.Services);
            ConfigureDatabase(builder.Services);
            ConfigureDependencyInjection(builder.Services);
            ConfigureOpenApi(builder.Services);

            var app = builder.Build();
            
            if (app.Environment.IsDevelopment())
            {
                ApplyMigrationsInDevelopment(app);
                ConfigureOpenApiInDevelopment(app);
            }

            ConfigureMiddleware(app);
            ConfigureEndpoints(app);

            app.Run();
        }

        #region Service Configuration

        private static void ConfigureControllers(IServiceCollection services)
        {
            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                });
        }
        
        private static void ConfigureCors(IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("ApiCorsPolicy", policy =>
                {
                    policy.WithOrigins(
                            configuration.GetSection("AllowedOrigins").Get<string[]>()
                            ?? new[] { "http://localhost:4200", "https://test-web-kappa-woad.vercel.app" })
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowCredentials();
                });
            });
        }

        private static void ConfigureAuthentication(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configuration["JwtSettings:Issuer"],
                        ValidAudience = configuration["JwtSettings:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(configuration["JwtSettings:JWTSecretKey"]))
                    };

                    options.Events = new JwtBearerEvents
                    {
                        OnChallenge = async context =>
                        {
                            context.HandleResponse();
                            context.Response.StatusCode = 401;
                            context.Response.ContentType = "application/json";

                            var result = Result<object>.Failure("Token inválido o expirado");
                            await context.Response.WriteAsJsonAsync(result);
                        }
                    };
                });
        }

        private static void ConfigureAuthorization(IServiceCollection services)
        {
            services.AddAuthorization();
            services.AddHttpContextAccessor();
        }
        private static void ConfigureMapping(IServiceCollection services)
        {
            services.AddMapster();
            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(typeof(UserMappingConfig).Assembly);
        }

        private static void ConfigureDatabase(IServiceCollection services)
        {
            services.AddScoped<ITenantContext, TenantContext>(sp =>
            {
                var httpContext = sp.GetRequiredService<IHttpContextAccessor>().HttpContext;
                var tenant = httpContext?.Items["Tenant"] as Tenant;
                //var tenant = new Tenant { TenantName = "Valmarq", TenantKeyName = "ValmarqDBConeectionString", Active = true };

                if (tenant == null)
                    throw new InvalidOperationException("Tenant no resuelto");

                return new TenantContext(tenant);
            });

            services.AddDbContext<TenantDbContext>((sp, options) =>
            {
                var tenantContext = sp.GetRequiredService<ITenantContext>();
                var tenant = tenantContext.GetTenant();

                options.UseSqlServer(
                    tenant.DatabaseConnectionString,
                    //"Server=localhost;Database=TLSDB;User Id=sa;Password=Admin;TrustServerCertificate=True;",
                    sql =>
                    {
                        sql.EnableRetryOnFailure(5, TimeSpan.FromSeconds(30), null);
                        sql.CommandTimeout(60);
                    });
            });

            services.AddScoped<IDbContextFactory, TenantDbContextFactory>();
        }
        private static void ConfigureDependencyInjection(IServiceCollection services)
        {
            services.AddScoped<IJwtGenenrator, JwtGenenrator>();
            services.AddScoped<IAuthService, AuthService>();

            services.AddScoped<ITenantService, TenantService>();            
            services.AddScoped<ICustomerervice, Customerervice>();
            services.AddScoped<IEquipmentService, EquipmentService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRolService, RolService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<ILogisticsProviderService, LogisticsProviderService>();
            services.AddScoped<ITerminalService, TerminalService>();
            services.AddScoped<IRoadRouteService, RoadRoutesService>();
            services.AddScoped<IContainerService, ContainerService>();
            services.AddScoped<IIMOService, IMOService>();
            services.AddScoped<IServiceService, ServiceService>();
            services.AddScoped<ITripTypeService, TripTypeService>();
            services.AddScoped<IEquipmentTypeService, EquipmentTypeService>();
            services.AddScoped<IContainerTypeService, ContainerTypeService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITenantRepository, TenantRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IEquipmentRepository, EquipmentRepository>();
            services.AddScoped<IRolRepository, RolRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<ILogisticsProviderRepository, LogisticsProviderRepository>();
            services.AddScoped<ITerminalRepository, TerminalRepository>();
            services.AddScoped<IRoadRouteRepository, RoadRouteRepository>();
            services.AddScoped<IContainerRepository, ContainerRepository>();
            services.AddScoped<IIMORepository, IMORepository>();
            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<ITripTypeRepository, TripTypeRepository>();
            services.AddScoped<IEquipmentTypeRepository, EquipmentTypeRepository>();
            services.AddScoped<IContainerTypeRepository, ContainerTypeRepository>();
        }

        private static void ConfigureOpenApi(IServiceCollection services)
        {
            services.AddOpenApi();
        }

        #endregion

        #region Middleware Configuration

        private static void ConfigureMiddleware(WebApplication app)
        {
            app.UseRouting();
            app.UseMiddleware<ExceptionHandlerMiddleware>();
            app.UseMiddleware<SecurityHeadersMiddleware>();
            app.UseCors("ApiCorsPolicy");
            app.UseMiddleware<ApiKeyValidationMiddleware>();
            app.UseMiddleware<TenantMiddleware>();
            app.UseMiddleware<RateLimitingMiddleware>();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseHttpsRedirection();
        }

        private static void ConfigureEndpoints(WebApplication app)
        {
            app.MapControllers();
        }

        #endregion

        #region Development Configuration

        private static void ConfigureOpenApiInDevelopment(WebApplication app)
        {
            app.MapOpenApi()
                .AllowAnonymous()
                .WithMetadata(new SkipTenantValidationAttribute())
                .WithMetadata(new SkipApiKeyValidationAttribute());

            app.MapScalarApiReference()
                .AllowAnonymous()
                .WithMetadata(new SkipTenantValidationAttribute())
                .WithMetadata(new SkipApiKeyValidationAttribute());
        }

        private static void ApplyMigrationsInDevelopment(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();

                var tenantConnectionStrings = new Dictionary<string, string>
                {
                    { "Valmarq", configuration.GetConnectionString("ValmarqDBConeectionString")! },
                    { "Tenant2", configuration.GetConnectionString("Tenant2DBConnectionString")! }
                };

                foreach (var tenant in tenantConnectionStrings)
                {
                    try
                    {
                        Console.WriteLine($"Aplicando migraciones a: {tenant.Key}...");

                        var optionsBuilder = new DbContextOptionsBuilder<TenantDbContext>();
                        optionsBuilder.UseSqlServer(tenant.Value, sqlOptions =>
                        {
                            sqlOptions.EnableRetryOnFailure(5, TimeSpan.FromSeconds(30), null);
                            sqlOptions.CommandTimeout(60);
                        });

                        using var context = new TenantDbContext(optionsBuilder.Options);
                        context.Database.Migrate();

                        Console.WriteLine($"✅ Migraciones aplicadas a {tenant.Key}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"❌ Error en {tenant.Key}: {ex.Message}");
                    }
                }
            }
        }

        #endregion
    }
}