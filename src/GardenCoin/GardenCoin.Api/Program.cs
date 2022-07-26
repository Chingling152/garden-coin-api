using GardenCoin.Infra.Data.Extensions;
using GardenCoin.Auth.Infra.Data.Extensions;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration;
builder.Services.AddAuthInfra(config);
builder.Services.AddCoreInfra(config);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
