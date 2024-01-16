using Microsoft.EntityFrameworkCore;
using Npgsql;
using Services.CuponAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var conStrBuilder = new NpgsqlConnectionStringBuilder(
        builder.Configuration.GetConnectionString("DefaultConnection"));
conStrBuilder.Password = builder.Configuration["DbPassword"];
var connection = conStrBuilder.ConnectionString;


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
