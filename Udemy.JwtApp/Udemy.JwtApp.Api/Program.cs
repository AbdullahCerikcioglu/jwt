using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;
using Udemy.JwtApp.Api.Core.Application.Interfaces;
using Udemy.JwtApp.Api.Core.Application.Mappings;
using Udemy.JwtApp.Api.Infrastructure.Tools;
using Udemy.JwtApp.Api.Persistance.Context;
using Udemy.JwtApp.Api.Persistance.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.RequireHttpsMetadata = false;
    opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidAudience = JwtTokenDefaults.ValidAudience,
        ValidIssuer   = JwtTokenDefaults.ValidIssuer,
        ClockSkew = TimeSpan.Zero,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key)),
        ValidateIssuerSigningKey= true,
        ValidateLifetime= true,



    };
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<JwtContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Local"));
});


builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository_T_<>));
builder.Services.AddMediatR(Assembly.GetExecutingAssembly()); //command ve qury i ayýran yapý.
//mapping iþlemleri için
builder.Services.AddAutoMapper(opt =>
{
     opt.AddProfiles(new List<Profile>()
     {
         new ProductProfile(),
         new CategoryProfile()
     });

});




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
