using Microsoft.EntityFrameworkCore;
using PeopleApp.Api.Data;
using PeopleApp.Api.Data.DefaultData;
using PeopleApp.Api.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("PeopleConnection");
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddScoped<IPeopleService, PeopleService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<ILocationService, LocationService>();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.SeedDatabase();
//SeedData.SeedDatabase(app);

app.Run();
