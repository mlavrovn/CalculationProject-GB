using FluentValidation.AspNetCore;
using CalculationProject.Api.Middleware;
using CalculationProject.BusinessLogic.Interfaces;
using CalculationProject.BusinessLogic.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using CalculationProject.Api.DTOs.Validators;

namespace CalculationProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CalculationDTOValidator>());


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSingleton<ICalculationStrategyFactory, CalculationStrategyFactory>();
            builder.Services.AddTransient<ICalculationService, CalculationService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseErrorHandlerMiddleware();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
