// using  OrderManager;
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore;
using OrderApi.Controllers;
using OrderManager;
using OrderApi;

var builder = WebApplication.CreateBuilder(args);

// 添加数据库上下文
builder.Services.AddDbContext<OrderContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))));

// 注册 OrderService
builder.Services.AddScoped<OrderService>();

// 添加控制器
builder.Services.AddControllers()
   .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
    });

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
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