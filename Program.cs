using Microsoft.EntityFrameworkCore;
using CarMaintenance.Data;
using CarMaintenance.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<CarsDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CarMaintenanceContext")));
builder.Services.AddDbContext<CarsAuthDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CarMaintenanceAuth")));

// Register repositories
builder.Services.AddScoped<IMaintenanceRecordRepository, SQLServerMaintenanceRecord>();
builder.Services.AddScoped<ICarRepository, SQLServerCarRepository>();
builder.Services.AddScoped<IUserRepository, SQLServerUserRepository>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
{
    ValidateIssuer = true,
    ValidateAudience = true,
    ValidateLifetime = true,
    ValidateIssuerSigningKey = true,
    ValidIssuer = builder.Configuration["Jwt:Issuer"],
    ValidAudience = builder.Configuration["Jwt:Audience"],
    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
