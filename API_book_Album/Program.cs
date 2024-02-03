using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Implementation;
using Repository.Interface;
using Services.Implemetation;
using Services.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var connection = builder.Configuration["MySQLConnection:MySQLConnectionString"];
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(
    connection,
    new MySqlServerVersion(new Version(8, 3, 0)))
);


builder.Services.AddScoped<IService, BookService>();
builder.Services.AddScoped<IRepository, BookRepository>();

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
