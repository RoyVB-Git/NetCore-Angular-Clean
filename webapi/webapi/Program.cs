using dal;
using dal.Repositories;
using logic.Services;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var dbConnectionString = builder.Configuration.GetSection("DatabaseConnectionString").Value;
builder.Services.AddDbContext<MainDbContext>(options =>
{
    options.UseSqlServer(dbConnectionString,
        sqlOptions =>
        {
            sqlOptions.EnableRetryOnFailure(
                10,
                TimeSpan.FromSeconds(30),
                null);
        }).EnableSensitiveDataLogging();
});

builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
});

// Repositories
builder.Services.AddScoped<IGameRepository, GameRepository>();

// Services
builder.Services.AddScoped<IGameService, GameService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        build =>
        {
            build.SetIsOriginAllowed(_ => true)
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}



app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

public class DesignTimeMainDbContext : IDesignTimeDbContextFactory<MainDbContext>
{
    MainDbContext IDesignTimeDbContextFactory<MainDbContext>.CreateDbContext(string[] args)
    {
#if DEBUG
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.Development.json")
            .Build();
#else
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
#endif

        var builder = new DbContextOptionsBuilder<MainDbContext>();
        var connectionString = configuration.GetSection("DatabaseConnectionString").Value;

        builder.UseSqlServer(connectionString);

        return new MainDbContext(builder.Options);
    }
}
