using Microsoft.EntityFrameworkCore;
using Npgsql;
using Services.CuponAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
//conStrBuilder.Password = builder.Configuration["DbPassword"];
//var connection = conStrBuilder.ConnectionString;


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

ApplyMigration();

app.MapControllers();

app.Run();

// get the appDbContext here and check if there are any pending migrations, if there are, will aplly them
void ApplyMigration()
{
    using (var scope = app.Services.CreateScope())
    {
        var _db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        if(_db.Database.GetPendingMigrations().Count() > 0)
        {
            // this will automatically add all the pending migrations to the database
            _db.Database.Migrate();
        }
    }
}