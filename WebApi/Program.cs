using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Middleware;
using WebApi.DbOperations;
using WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//benim eklediğim kısım2
builder.Services.AddDbContext<KitapSepetiDbContext>(option => option.UseInMemoryDatabase(databaseName : "KitapSepetiDb"));
builder.Services.AddScoped<IKitapSepetiDbContext>(provider => provider.GetService<KitapSepetiDbContext>());

//autoMapper eklediğim kısım1
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly()); 

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//logger servis eklediğim kısım
builder.Services.AddSingleton<ILoggerService, ConsoleLogger>();

var app = builder.Build();

//benim eklediğim kısım1
using (var scope = app.Services.CreateScope()) 
        { var services = scope.ServiceProvider; 
          DataGenerator.Initialize(services); }

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//middleware eklediğim kısım
app.UseCustomExeptionMiddleware();

app.MapControllers();

app.Run();
