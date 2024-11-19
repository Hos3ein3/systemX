
using Weasel.Core;

var builder = WebApplication.CreateBuilder(args);
// dependency Injection
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});
builder.Services.AddCarter();
builder.Services.AddMarten(opt =>
{
    opt.Connection(builder.Configuration.GetConnectionString("Database")!);
    opt.AutoCreateSchemaObjects = builder.Environment.IsDevelopment() ?
        AutoCreate.CreateOrUpdate : AutoCreate.None;
}).UseLightweightSessions();

var app = builder.Build();

//! Configure the HTTP requests pipeline.

//app.ConfiguresApp();
app.MapCarter();

app.Run();
