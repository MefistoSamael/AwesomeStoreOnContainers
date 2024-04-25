using Duende.IdentityServer.Models;
using Duende.IdentityServer.Test;
using Identity;
using Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddAuthorization();

//builder.Services.AddIdentityApiEndpoints<IdentityUser>()
//    .AddEntityFrameworkStores<ApplicationDbContext>();

//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//builder.Services.AddDefaultIdentity<IdentityUser>()
//    .AddRoles<IdentityRole>();

//.AddRoles<IdentityRole>();

builder.Services.AddIdentityServer().AddTestUsers(new List<TestUser>(TestUsers.Users))
.AddInMemoryClients(new List<Client>(Config.Clients))
.AddInMemoryApiResources(new List<ApiResource>(Config.ApiResources))
.AddInMemoryApiScopes(new List<ApiScope>(Config.ApiScopes))
.AddInMemoryIdentityResources(new List<IdentityResource>(Config.IdentityResources));

var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.MapIdentityApi<IdentityUser>();
app.UseIdentityServer();
app.MapGet("/", () => "Hello World!");


app.Run();
