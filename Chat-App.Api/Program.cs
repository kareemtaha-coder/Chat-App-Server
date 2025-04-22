using Chat_App.Api.Data;
using Chat_App.Api.Entities;
using Chat_App.Api.GraphQl;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddCors();

// GraphQL configuration
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddType<AppUser>() // 👈 Needed
    .AddProjections()
    .AddFiltering()
    .AddSorting();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.UseCors(options =>
{
    options.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});

// Map controllers and GraphQL endpoint
app.MapControllers();
app.MapGraphQL(); // Default path: /graphql

app.Run();