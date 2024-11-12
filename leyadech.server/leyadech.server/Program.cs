using leyadech.server.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<MotherService>();
builder.Services.AddScoped<VolunteerService>();
builder.Services.AddScoped<RequestService>();
builder.Services.AddScoped<SuggestService>();
builder.Services.AddScoped<VolunteeringService>();
builder.Services.AddScoped<DataContext.DataPathes>();
builder.Services.AddScoped<IDataContext, DataContext>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
