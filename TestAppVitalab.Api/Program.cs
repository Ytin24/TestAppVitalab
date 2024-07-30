
using Mapster;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using TestAppVitalab.Api.DAL.Context;

namespace TestAppVitalab.Api {
    public class Program {
        public static void Main(string[] args) {

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<VitalabTestDbContext>(
            options => {
                options.UseSqlServer("name=ConnectionStrings:VitalabTestDb");
                options.UseLoggerFactory(LoggerFactory.Create(builder => {
                    builder.AddFilter((category, level) => level >= LogLevel.Warning);
                }));
            });
            builder.Services.AddControllers();
            builder.Services.AddMapster();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment()) {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
