using AdminService.Attributes;
using AdminService;
using AdminService.Services.ValidationService;
using AdminService.Utilities.EmailServiceUtility;
using AdminService.Utilities.PasswordHashUtility;
using Microsoft.EntityFrameworkCore;
using AdminService.Services.AdminAccountService;
using AdminApi;
using AdminService.Services.InternalAdminAccountService;

var builder = WebApplication.CreateBuilder(args);

var server = Environment.GetEnvironmentVariable("DB_SERVER");
var port = Environment.GetEnvironmentVariable("DB_PORT");
var database = Environment.GetEnvironmentVariable("DB_NAME");
var user = Environment.GetEnvironmentVariable("DB_USER");
var password = Environment.GetEnvironmentVariable("DB_PASSWORD");
//var connectionString = $"Server={server};Port={port};Database={database};User={user};Password={password};";
var connectionString = $"Server=localhost;Port=3306;Database=vehicleadmindb;User=root;Password=;";

GlobalAttributes.mySQLConfig.connectionString = connectionString;
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Add services to the container.
builder.Services.AddScoped<ICreateAdminValidationService, CreateAdminValidationService>();
builder.Services.AddScoped<IPasswordHashUtilityService, PasswordHashUtilityService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IAdminAccountService, AdminAccountService>(); 
builder.Services.AddScoped<IInternalAdminAccountService, InternalAdminAccountService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
