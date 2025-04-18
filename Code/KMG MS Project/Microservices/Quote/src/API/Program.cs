using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Quotes.BusinessLayer.Interfaces;
using Quotes.BusinessLayer.Services;
using Quotes.DataAccessLayer;
using Quotes.DataAccessLayer.Utilities;
using Serilog;

namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add controllers with modified formatters to enforce JSON response
            builder.Services.AddControllers(options =>
            {
                // Remove XML formatter support to force JSON response
                options.RespectBrowserAcceptHeader = true;
                options.OutputFormatters.RemoveType<Microsoft.AspNetCore.Mvc.Formatters.XmlSerializerOutputFormatter>();
            });

            builder.Services.AddSingleton<DapperContext>();
            builder.Services.AddScoped<IDataAccess, DataAccess>();

            builder.Services.AddScoped<IQuoteService, QuoteService>();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Configure Serilog
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day)
                .Enrich.FromLogContext()
                .MinimumLevel.Debug()
                .CreateLogger();

            builder.Host.UseSerilog();

            var app = builder.Build();
            app.UseSerilogRequestLogging();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
