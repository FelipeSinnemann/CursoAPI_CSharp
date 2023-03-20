using Curso.Repository.Context;
using Curso.Repository.Interfaces;
using Curso.Repository.Repository;
using Curso.Service.Interfaces;
using Curso.Service.Services;
using Microsoft.EntityFrameworkCore;

namespace Curso.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<CursoDBContext>(options =>
            {
                var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
                var connectionMysql = config["ConnectionStrings:CursoAppelSoft"].ToString();
                options.UseMySQL(builder.Configuration.GetConnectionString("CursoAppelSoft"));
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<ITipoVeiculoRepository, TipoVeiculoRepository>();
            builder.Services.AddScoped<ITipoVeiculoService, TipoVeiculoService>();

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