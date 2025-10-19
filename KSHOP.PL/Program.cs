using KSHOP1.BLL.Services.Clasess;
using KSHOP1.BLL.Services.Clasess;
using KSHOP1.BLL.Services.Interfaces;
using KSHOP1.DAL.Data;
using KSHOP1.DAL.Repositories.Classes;
using KSHOP1.DAL.Repositories.Interfaces;
using KSHOP1.DAL.Utils;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

namespace KSHOP.PL;

public class Program
{

    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container
        builder.Services.AddControllers();
        builder.Services.AddOpenApi();

        builder.Services.AddAuthentication();
        builder.Services.AddAuthorization();

        // Register ApplicationDbContext with SQL Server
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        // Register repositories and services
        builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
        builder.Services.AddScoped<ICategoryService, CategoryService>();

        builder.Services.AddScoped<IBrandRepository, BrandRepository>();
        builder.Services.AddScoped<IBrandService, BrandService>();
        builder.Services.AddScoped<ISeedData, SeedData>();

        var app = builder.Build();

        // Configure the HTTP request pipeline
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.MapScalarApiReference();
        }

        var scope = app.Services.CreateScope();
        var objectOfSeedData = scope.ServiceProvider.GetRequiredService<ISeedData>();
        objectOfSeedData.DataSeeding();




        app.UseHttpsRedirection();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
