using Microsoft.EntityFrameworkCore;
using MyWardrobeApi.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string not found.");

// Add services to the container.
builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options => {
        options.SuppressModelStateInvalidFilter = true;
    });
builder.Services.AddDbContext<WardrobeContext>(options =>
    options.UseSqlite(connectionString));

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

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error");
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
