using FizzBuzz.Api.Endpoints;
using FizzBuzz.Api.Extensions;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.RegisterFizzBuzzServices();

var app = builder.Build();

app.MapGet("/",
    (
        [FromServices] FizzBuzzEndpoint fizzBuzzEndpoint
    ) => fizzBuzzEndpoint.GetFizzBuzz)
    .WithOpenApi();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();


