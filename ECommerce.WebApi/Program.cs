using ECommerce.Business.Abstract;
using ECommerce.Business.AutoMapper;
using ECommerce.Business.ConCreate;
using ECommerce.Business.FluentValidation;
using ECommerce.Core;
using ECommerce.DataAccess.Abstract;
using ECommerce.DataAccess.ConCreate;
using ECommerce.DataAccess.Context;
using ECommerce.WebApi.Filter;
using ECommerce.WebApi.Middleware;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();


// builder.Services.AddScoped<IUserRepository, UserRepository>();
// builder.Services.AddScoped<IProductRepository, ProductRepository>();
// builder.Services.AddScoped<IOrderRepository, OrderRepository>();
//
// builder.Services.AddScoped<IUserService, UserManager>();
// builder.Services.AddScoped<IProductService, ProductManager>();
// builder.Services.AddScoped<IOrderService, OrderManager>();
//
// // builder.Services.AddScoped<ValidationFilter>();
//

builder.Services.CreateServices();
builder.Services.AddValidatorsFromAssemblyContaining<UserDtoValidation>();
builder.Services.AddAutoMapper(conf => conf.AddMaps(typeof(UserManager).Assembly));

var config = new ConfigurationManager().AddJsonFile("appsettings.json").Build();
builder.Services.AddDbContext<ECommerceDBContext>(options =>
{
    options.UseMySQL(config["Mysql"]);
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

