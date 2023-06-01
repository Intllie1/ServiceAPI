using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using RegistrationAPI.BusinessService.Interfaces;
using RegistrationAPI.DataAccess.Models;
using RegistrationAPI.objects.Proxies;
using RegistrationAPI.BusinessService;
using RegistrationAPI.DataAccess.Context;
using System.Diagnostics.Eventing.Reader;
using System.Data.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Register interface and class which we injected

//builder.Services.AddDbContext<SQLContext>(x => x.UseSqlServer(connectionString));
var dbcheck = builder.Configuration.GetSection("DBCheck").Value;
var connectionString = string.Empty;
if (dbcheck == "1") {
    connectionString = builder.Configuration.GetSection("MySQLConnectionStrings").GetSection("DefaultConnection").Value;
    builder.Services.AddDbContext<MySQLDBContext>(options =>
    {
        _ = options.UseMySQL(connectionString);
    });
}
else if (dbcheck == "2") {
    connectionString = builder.Configuration.GetSection("SQLConnectionStrings").GetSection("DefaultConnection").Value;
    builder.Services.AddDbContext<MySQLDBContext>(options =>
    {
        _ = options.UseSqlServer(connectionString);
    });
}
else if (dbcheck == "3")
{
    connectionString = builder.Configuration.GetSection("AZURE_SQL_CONNECTIONSTRING").GetSection("DefaultConnection").Value;
    builder.Services.AddDbContext<MySQLDBContext>(options =>
    {
        _ = options.UseSqlServer(connectionString);
    });
}
//Server=localhost;Database=master;Trusted_Connection=True;
//// Register interface and classes
//builder.Services.AddScoped<IRegistration, Registration>();
builder.Services.AddScoped<IRegistration<Registration>, RegistrationService>();
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
