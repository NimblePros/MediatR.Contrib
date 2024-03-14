using FastEndpoints;
using System.Reflection;
using Serilog;

var logger = Log.Logger = new LoggerConfiguration()
  .Enrich.FromLogContext()
  .WriteTo.Console()
  .CreateLogger();

logger.Information("Starting web host");


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Host.UseSerilog((_, config) => config.ReadFrom.Configuration(builder.Configuration));
builder.Services.AddHttpLogging(o => { });

builder.Services.AddFastEndpoints();

// Set up MediatR
builder.Services.AddMediatR(cfg =>
cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
//builder.Services.AddMediatRLoggingBehavior();
//builder.Services.AddMediatRFluentValidationBehavior();
//builder.Services.AddValidatorsFromAssemblyContaining<AddItemToCartCommandValidator>();
//builder.Services.AddScoped<IDomainEventDispatcher, MediatRDomainEventDispatcher>(); // domain events


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpLogging();

app.UseFastEndpoints();

app.Run();

