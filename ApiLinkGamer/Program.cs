using ApiLinkGamer.Configuration;
using ApiLinkGamer.ServiceStart;
using Data.Context;
using Domain.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Middleware;
using System.Configuration;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add configurations
var services = builder.Services;
DependencyInjection.AddDependencies(ref services);

//Service
builder.Services.AddControllers();
ApiLinkGamerService.Start(ref services);
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "ApiLinkGamer", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiLinkGamer v1"));
}


app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<InterceptorApiLinkGamerMiddleware>();
app.MapControllers();
app.Run();
