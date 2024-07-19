using Microsoft.EntityFrameworkCore;
using Vertr.Orders.Application;
using Vertr.Orders.Infrastructure.DataAccess;
using Vertr.Orders.Infrastructure.TproxyConnector;

namespace Vertr.Orders.Server;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddAppMediator();
        builder.Services.AddTpoxy(new Uri("http://localhost:5100"));

        builder.Services.AddDataAccess(options =>
        {
            options.UseNpgsql(builder.Configuration.GetConnectionString("OrdersContext"));
        });

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
