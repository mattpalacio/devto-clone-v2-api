using DevtoCloneV2.Api.Extensions;
using DevtoCloneV2.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add data access services
builder.Services.AddDataAccessServices(builder.Configuration.GetConnectionString("LocalDb"));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add mapper
builder.Services.AddMapperService();

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
