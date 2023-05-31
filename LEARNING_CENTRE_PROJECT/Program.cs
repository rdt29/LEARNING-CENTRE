using FluentValidation.AspNetCore;
using LEARNING_CENTRE_PROJECT.Configuration;
using LEARNING_CENTRE_PROJECT.GlobalException;
using LearningCentre.Core.Services.Helper.Interface;
using Microsoft.AspNetCore.OData;
using Microsoft.OpenApi.Models;
using SendGrid.Extensions.DependencyInjection;
using Serilog;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;

//global using SimpleEmailApp.Services.EmailServices;
//global using SimpleEmailApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSqlServerr(builder.Configuration);
builder.Services.AddControllers().AddFluentValidation(c => c.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//-------------------OData---------------------//
builder.Services.AddControllers()
    .AddOData(options => options.Select().Filter().Expand().Count().OrderBy());
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo", Version = "v1" });
});

builder.Services.AddAuthentications(builder.Configuration);
builder.Services.AddNewtonJson();
//--------------AutoMapper-----------------//
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSwaggerGen().AddDependencyInjection();
//Log.Logger = new LoggerConfiguration().CreateBootstrapLogger();

var logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.MSSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), "Logs")
     .CreateLogger();
builder.Logging.AddSerilog(logger);
//?--------------------------------------SendGrid-------------------------------------------------------

#region sendgrid

builder.Services.AddSendGrid(options =>
{
    options.ApiKey = builder.Configuration
    .GetSection("SendGridEmailSettings").GetValue<string>("APIKey");
});

#endregion sendgrid

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme(\"bearer {token}\")",

        In = ParameterLocation.Header,

        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//? GLobal Exception handling----------------------------
app.UseMiddleware<GlobalException>();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();