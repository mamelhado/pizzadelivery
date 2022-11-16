using AutoMapper;
using Delivery.Api.Mapper;
using Delivery.Data;
using Delivery.Data.Repositories;
using Delivery.Domain.Interfaces.Repositories;
using Delivery.Domain.Interfaces.Services;
using Delivery.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var env = Environment.GetEnvironmentVariable("ENV");

if (env == null)
{
    builder.Configuration.AddJsonFile("appsettings.local.json", optional: true, reloadOnChange: true);
}
else 
{
    builder.Configuration.AddJsonFile($"appsettings.{env.ToLower()}.json", optional: true, reloadOnChange: true);
}

string connString = builder.Configuration.GetConnectionString("Mvp");
// Add services to the container.
builder.Services.AddDbContext<DeliveryContext>(opt => 
{
    opt.UseNpgsql(connString);
    opt.UseLazyLoadingProxies(true);
},ServiceLifetime.Transient);

builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<ISubCategoryRepository, SubCategoryRepository>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<ISubCategoryService, SubCategoryService>();


builder.Services.AddAutoMapper(cfg =>
{
    cfg.ConfigureAutoMapper();
});

builder.Services.AddControllers();
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
