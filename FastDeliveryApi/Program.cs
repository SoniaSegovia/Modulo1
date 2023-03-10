using FastDeliveryApi.Data;
using FastDeliveryApi.Middleware;
using FastDeliveryApi.Repositories;
using FastDeliveryApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.addScoped<IUnitOfWork, UnitOfWork>();
builder.Services.addScoped<ICustomerRepository, CustomerRepository>();

builder.Services.Decorate<ICustomerRepository, CachedCustomerRepository>();

builder.Services.AddMemoryCache();

var connectionString = builder.Configuration.GetConnectionString("MyDbPgsql");
builder.Services.AddDbContext<FastDeliveryDbContext>(options =>{
    options.UseNpgsql(connectionString);
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => {
    options.AddPolicy("AllowAll",
    b => b.AllowAnyHeader()
              .AllowAnyOrigin()
              .AllowAnyMethod());
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.useCors("AllowAll");

app.UseAuthorization();

app.MapControllers();
 
 app.Run();
