using Belek.API;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Belek.API.Quizes.GetQuiz;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureCosmosDb();
builder.Services.AddMediatR(cfg =>
     cfg.RegisterServicesFromAssembly(typeof(InfrastructureSetUp).Assembly));
builder.Services.AddValidatorsFromAssembly(typeof(InfrastructureSetUp).Assembly);
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
builder.Services.AddScoped<ExceptionHandlingMiddleware>();
var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/{queryName}", async (string queryName, [FromQuery]string id, IMediator mediator) => await mediator.Send(new GetQuizQuery(id)))
    .WithName("Query")
    .WithOpenApi();

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
