using Leyadech.Api.Extensions;
using Leyadech.Core.Entities;
using Leyadech.Core.Repositories;
using Leyadech.Core.Services;
using Leyadech.Data;
using Leyadech.Data.Repositories;
using Leyadech.Service;
using static Leyadech.Data.DataContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ServiceDependencyInjector();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
    });
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
