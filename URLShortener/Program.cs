using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;
using URLShortener;
using URLShortener.Helpers;
using URLShortener.IHelpers;
using URLShortener.IRepository;
using URLShortener.Mapping;
using URLShortener.Models;
using URLShortener.Repositories;
using URLShortener.Services;
using URLShortener.UnitOfWorks;
using URLShortener.Validation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddFluentValidation(options =>
    {
        options.RegisterValidatorsFromAssemblyContaining<UrlDtoValidator>();                
    });
    

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));
builder.Services.AddScoped(typeof(IUrlService), typeof(UrlService));
builder.Services.AddScoped(typeof(IUrlRepository), typeof(UrlRepository));
builder.Services.AddScoped(typeof(IUrlControllerHelper), typeof(UrlControllerHelper));
builder.Services.AddAutoMapper(typeof(MapProfile));

builder.Services.AddDbContext<ShortenerDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConStr"), option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(ShortenerDbContext)).GetName().Name);
    });
});


//var connStr = builder.Configuration.GetConnectionString("SqlConStr");
//builder.Services.AddDbContext<ShortenerDbContext>(options => options.UseSqlServer(connStr));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


//app.MapPost("/shorturl", async (UrlDto url, ShortenerDbContext db , HttpContext ctx) => {

//});
app.UseAuthorization();

app.MapControllers();

app.Run();
