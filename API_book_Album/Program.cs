using Businnes;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Repository.Context;
using Repository.GenericRepository;
using Services.Implemetation;
using Services.Interface;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var connection = builder.Configuration["MySQLConnection:MySQLConnectionString"];
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(
    connection,
    new MySqlServerVersion(new Version(8, 3, 0)))
);


builder.Services.AddScoped <IBasicService<Book>,BookService>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Book and Album API",
        Description = "Api Rest de livros e álbuns musicais",
        Contact = new OpenApiContact
        {
            Name = "Junior Lemos",
            Url = new Uri("https://github.com/juniorlemos")
        },
        
    });
   
});
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
