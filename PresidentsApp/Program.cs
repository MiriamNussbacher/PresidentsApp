using Repository;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<IPresidentService, PresidentService>();
builder.Services.AddTransient<IPresidentRepository, FilePresidentRepository>();
builder.Services.AddScoped<IIncriment, Incriment>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
