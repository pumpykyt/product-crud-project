using System.Data;
using CrudProject.Application.Handlers;
using CrudProject.Application.Profiles;
using CrudProject.Data;
using CrudProject.Domain.Interfaces;
using CrudProject.Domain.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options => options.UseNpgsql(builder.Configuration["ConnectionString"], 
                                                 b => b.MigrationsAssembly("CrudProject.Web"))
);
builder.Services.AddMediatR(typeof(GetProductsHandler));
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddScoped<IProductService, ProductService>();

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