
using eCommerce.Models.Entities;
using eCommerce.Services;
using eCommerce.Services.Interfaces;
using Mapster;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IUsersService, UsersService>();

builder.Services.AddMapster();

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("eCommerceConnection");

builder.Services.AddDbContext<AppDbContext>(
    options =>
    {
        options.UseSqlServer(connectionString);
    }
);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
}






app.UseHttpsRedirection();





app.MapControllers();
app.Run();

