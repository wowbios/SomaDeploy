using System.Reflection;
using MediatR;
using Soma.Application.Handlers.AppRegistry;
using Soma.Data;
using Soma.Data.AppChannel;
using Soma.Data.AppRegistry;
using Soma.Domain.AppChannel;
using Soma.Domain.AppRegistry;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DB
builder.Services
    .AddSingleton<DapperContext>()
    .AddScoped<IAppRegistryRepository, AppRegistryRepository>()
    .AddScoped<IAppChannelRepository, AppChannelRepository>();

builder.Services.AddMediatR(typeof(GetHandler));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();