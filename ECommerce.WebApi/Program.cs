using ECommerce.Business.ConCreate;
using ECommerce.Business.FluentValidation;
using ECommerce.Core;
using ECommerce.DataAccess.Context;
using ECommerce.WebApi.Middleware;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.CreateServices();
builder.Services.AddValidatorsFromAssemblyContaining<UserDtoValidation>();
builder.Services.AddAutoMapper(conf => conf.AddMaps(typeof(UserManager).Assembly));

string? connectionString = GlobalConfigurations.GetConnectionString();
if (!string.IsNullOrEmpty(connectionString))
    throw new Exception("Connection string not configured");

builder.Services.AddDbContext<ECommerceDBContext>(options =>
{
    options.UseMySQL(connectionString);
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware(typeof(GlobalExceptionMiddleware));

app.MapControllers();

app.Run();

