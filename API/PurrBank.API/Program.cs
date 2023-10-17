using Microsoft.OpenApi.Models;
using PurrBank.IoC;
using PurrBank.Tools;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();

builder.Services.AddRepositories();
builder.Services.AddEntitiesLogics();
builder.Services.AddDbContext();
builder.Services.AddMediatR();
builder.Services.AddSwaggerGen(c =>
{

    c.SwaggerDoc("v1", new OpenApiInfo
    {

        Version = "1.0.0",
        Title = "PurrBank API",
    });
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

});

builder.Configuration.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

builder.Services.AddControllers();

var connectionString = new ConnectionString();

connectionString.MySql = builder.Configuration.GetConnectionString("MySql");

AppSettings.ConnectionString = connectionString;


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseCors(options =>
options.AllowAnyOrigin()
.AllowAnyMethod()
.AllowAnyHeader()
);
app.MapControllers();
EnvironmentSetter.SetTestEnvToTrue();
app.Run();

