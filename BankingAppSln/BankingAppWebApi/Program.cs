using BankingAppWebApi.Data;
using BankingAppWebApi.Interfaces;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


// Adds DB Context for Entity Framework
builder.Services.AddDbContext<BankingContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BankingConnectionString")));
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    // Use the default property (Pascal) casing
    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
}); ;


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Adds Banking Repository to DI container
builder.Services.AddScoped<IBankingDbRepository, BankingDbRepository>();

// Addss DbInitialiser to DI Container
builder.Services.AddTransient<DbInitialiser>();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


// Seed Database with information
using var scope = app.Services.CreateScope();

var services = scope.ServiceProvider;

var initialiser = services.GetRequiredService<DbInitialiser>();

initialiser.Run();

//  End Seed Database


app.Run();
