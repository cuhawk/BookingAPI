using Bookings.IoC;
using Bookings.RepositoryEF.DataContext;
using Microsoft.EntityFrameworkCore;

namespace Bookings.API;

public class Program
{
    public static void Main(string[] args)
    {
        string cors = "MyCors";
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();
        builder.Services.AddCors(options => { options.AddPolicy(name: cors, builder => { builder.WithOrigins("*").AllowAnyMethod(); builder.AllowAnyHeader(); }); });
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddDependencies();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<PostgresqlDB>(opt => opt.UseNpgsql(connectionString: builder.Configuration.GetConnectionString("postgresql")));

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCors(cors);

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
