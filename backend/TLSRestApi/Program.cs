using Application.Interface.Repository;
using Application.Interface.Service;
using Application.Services;
using Infrastructure.Repositories;
using Infrastructure.Security;
using Microsoft.EntityFrameworkCore;
using Middleware;
using Scalar.AspNetCore;
using System.Text.Json;
using System.Text.Json.Serialization;
using TLSRestApi.Middleware;
using TLSRestApi.Attributes;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Domain.Common;
using System.Text;
using Domain.Entities;

namespace TLSRestApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            //builder.Services.AddControllers();
            builder.Services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            });

            /*builder.Services.AddCors(options =>
            {
                options.AddPolicy("ApiCorsPolicy", policy =>
                {
                    policy.WithOrigins(
                            builder.Configuration.GetSection("AllowedOrigins").Get<string[]>())
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowCredentials();
                });
            });*/

            // JWT Authentication
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
                        ValidAudience = builder.Configuration["JwtSettings:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:SecretKey"]))
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

            builder.Services.AddAuthorization();
            builder.Services.AddHttpContextAccessor();

            builder.Services.AddScoped<ITenantService, TenantService>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<ICustomerService, CustomerService>();
            builder.Services.AddScoped<IEquipmentService, EquipmentService>();


            builder.Services.AddScoped<IUserRepository,UserRepository>();
            builder.Services.AddScoped<ITenantRepository,TenantRepository>();
            builder.Services.AddScoped<IRepository<Customer>,CustomerRepository>();
            builder.Services.AddScoped<IRepository<Equipment>,EquipmentRepository>();
            builder.Services.AddScoped<IJwtGenenrator, JwtGenenrator>();

            builder.Services.AddOpenApi();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAngular",
                    policy =>
                    {
                        policy.WithOrigins(
                            "http://localhost:4200",
                            "https://test-web-kappa-woad.vercel.app")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();

                    });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi()
                    .AllowAnonymous()
                    .WithMetadata(new SkipTenantValidationAttribute());
                app.MapScalarApiReference()
                    .AllowAnonymous()
                    .WithMetadata(new SkipTenantValidationAttribute());
            }

            app.UseRouting();

            app.UseCors("AllowAngular");
            app.UseMiddleware<ExceptionHandlerMiddleware>();
            app.UseMiddleware<TenantMiddleware>();
            app.UseAuthentication();
            app.UseAuthorization(); 
            app.UseHttpsRedirection();
            

            app.MapControllers();

            app.Run();
        }
    }
}
