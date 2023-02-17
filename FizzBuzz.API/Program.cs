using FizzBuzz.Api.Endpoints;
using FizzBuzz.Api.Extensions;
using FizzBuzz.Api.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<FizzBuzzDatabaseOptions>(builder.Configuration.GetSection(nameof(FizzBuzzDatabaseOptions)));

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.RegisterFizzBuzzServices();

var app = builder.Build();

app.MapFizzBuzzEndpoint();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();


