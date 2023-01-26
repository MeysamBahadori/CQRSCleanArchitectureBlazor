using Mc2.CrudTest.Application.Customers;
using Mc2.CrudTest.Infrastructure;
using System.Reflection;
using MediatR;
using Mc2.CrudTest.Application.Mappers;

namespace Mc2.CrudTest.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Todo: move to extention
            builder.Services.AddAutoMapper(typeof(Program));
            builder.Services.AddAutoMapper(typeof(CustomerMapperConfiguration));
            builder.Services.AddAutoMapper(typeof(InfrastractureModule));

            builder.Services.AddMediatR(Assembly.GetExecutingAssembly(), typeof(GetCustomerByIdQuery).Assembly);

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //Modules DI
            InfrastractureModule.AddInfrastractureDI(builder.Services, builder.Configuration);

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