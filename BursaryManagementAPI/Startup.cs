﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using BusinessLogic;
using Azure.Storage.Blobs;
using DataAccess.Models;
using DataAccess;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;



public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        var connectionString = Configuration.GetConnectionString("DatabaseConnection");

        // Adding DB connection services to the dependency injection container (Single object used in the application's lifetime)
        services.AddSingleton<SqlConnection>(_ => new SqlConnection(connectionString));

        services.AddScoped<UserDAL>();
        services.AddScoped<StudentDAL>();
        services.AddScoped<UniversityAdminDAL>();
        services.AddScoped<UniversityAdminBLL>();
        services.AddScoped<StudentBLL>();
        services.AddScoped<BBDAdminBLL>();
        services.AddScoped<BBDAdminDAL>();
        services.AddScoped<ConstantTablesBLL>();
        services.AddScoped<ConstantTablesDAL>();


        // Adding Azure services to the dependency injection container (Scoped to instantiate a new object when requested)
        services.AddScoped(provider =>
        {
            var storageConnectionString = Configuration.GetConnectionString("AzureStorageConnectionString");
            var blobServiceClient = new BlobServiceClient(storageConnectionString);
            return blobServiceClient;
        });

       

        

        services.AddAuthentication(auth =>
        {
            auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidAudience = Configuration["AuthSettings:Audience"],
                ValidIssuer = Configuration["AuthSettings:Issuer"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["AuthSettings:Key"])),
                ValidateIssuerSigningKey = true,
            };
        });

        services.AddAuthorization(options =>
        {
            options.AddPolicy("RequireAdminRole", policy =>
                policy.RequireRole(Roles.BBDAdmin));
        });

        services.AddAuthorization(options =>
        {
            options.AddPolicy("RequireUniversityRole", policy =>
                policy.RequireRole(Roles.UniversityAdmin));
        });

        services.AddScoped<UserBLL>();
        services.AddScoped<StudentBLL>();

        services.AddControllers();

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "BursaryManagementAPI", Version = "v1" });
            c.AddSecurityDefinition("token", new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.Http,
                In = ParameterLocation.Header,
                Name = HeaderNames.Authorization,
                Scheme = "Bearer"
            });
        });

        // Add CORS services
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAnyOrigin",
                builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "BursaryManagementAPI v1");
            });
        }

        app.UseHttpsRedirection();
        app.UseRouting();

        // Enable CORS
        app.UseCors("AllowAnyOrigin");

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
