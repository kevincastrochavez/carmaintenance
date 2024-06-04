using Microsoft.EntityFrameworkCore;
using CarMaintenance.Data;
using CarMaintenance.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<CarsDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CarMaintenanceContext")));

builder.Services.AddScoped<IMaintenanceRecordRepository, SQLServerMaintenanceRecord>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

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
