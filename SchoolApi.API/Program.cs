using Microsoft.EntityFrameworkCore;
using SchoolApi.API;
using SchoolApi.Infrastructure.Configurations;
using System.Net.Sockets;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServices(builder.Configuration);

//// Add services to the container.

//string connectionString = builder.Configuration.GetConnectionString("SchoolDatabaseConnection") ??"";
//builder.Services.AddDbContext<SchoolDbContext>(
//    options => options.UseSqlServer(connectionString));

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

string? ipv4Address = (Dns.GetHostAddresses(Dns.GetHostName()).Where(ip => ip.AddressFamily == AddressFamily.InterNetwork).FirstOrDefault())?.ToString();
string? httpPath = $"http://{ipv4Address}:{5050}";

Console.WriteLine($"Server is running on https://{ipv4Address}:{7250}/swagger/index.html");
Console.WriteLine($"Server is running on http://{ipv4Address}:{5050}/swagger/index.html");

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
