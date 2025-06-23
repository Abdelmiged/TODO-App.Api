
using AutoMapper;
using Domain.Contracts.Repositories;
using Domain.Contracts.Repositories.ToDoModule;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Data.Contexts;
using Persistence.Repositories;
using Persistence.Repositories.ToDoModule;
using ServicesAbstraction.ServicesInterfaces.ToDoModule;
using ServicesImplementation.MappingProfiles.ToDoModule;
using ServicesImplementation.Services.ToDoModule;
using TODO_App.Api.Middlewares;

namespace TODO_App.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<StoreDbContext>(options =>
            {
                var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
                options.UseSqlServer(connectionString);
            });

            builder.Services.AddScoped<IToDoRepository, ToDoRepository>();
            builder.Services.AddAutoMapper(M => M.AddProfiles(new List<Profile> { new ToDoProfile()}));
            builder.Services.AddScoped<IToDoService, ToDoService>();

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

            app.UseMiddleware<CatchAllUnknownRouteHandlerMiddleware>();
            app.UseMiddleware<ExceptionHandlerMiddleware>();

            app.Run();
        }
    }
}
