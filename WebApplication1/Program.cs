using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebApplication1.Data;
using WebApplication1.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;Database=IdentityDb;Trusted_Connection=True;MultipleActiveResultSets=true")
);

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

builder.Services
    .AddIdentityApiEndpoints<User>()
    .AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.MapSwagger();

app.UseHttpsRedirection();

app.MapGet("/", (ClaimsPrincipal user) => $"Hello World, {user.Identity!.Name}")
    .RequireAuthorization();

app.MapPost("/logout",
    async (SignInManager<User> signInManager, [FromBody] object empty) =>
    {
        await signInManager.SignOutAsync();
        return Results.Ok();
    });

app.MapIdentityApi<User>();

app.Run();
