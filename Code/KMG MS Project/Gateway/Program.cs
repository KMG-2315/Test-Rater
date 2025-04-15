using Microsoft.Extensions.Configuration;
using MMLib.Ocelot.Provider.AppConfiguration;
using Ocelot.DependencyInjection;

namespace Gateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            IConfiguration configuration = new ConfigurationBuilder().Build();

            // Add services to the container.
            // Enable CORS to allow specific origins
            string[] allowOriginApis = configuration.GetSection("WebUrl:AllowOriginApis").Get<string[]>();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("allowSpecificOrigin",
                    builder =>
                    {
                        if (allowOriginApis != null && allowOriginApis.Length > 0)
                        {
                            builder.WithOrigins(allowOriginApis)
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                        }
                        else
                        {
                            builder.AllowAnyOrigin()  // Fallback to allow any origin if the array is null or empty
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                        }
                    });
            });
            builder.Services.AddControllers();
            builder.Services.AddOcelot().AddAppConfiguration();
            builder.Services.AddSwaggerForOcelot(builder.Configuration);
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
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