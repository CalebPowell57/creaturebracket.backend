using Api.Hubs;
using Db;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service.Extensions;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddAuthentication(IISDefaults.AuthenticationScheme)
////.AddFacebook(facebookOptions =>
////{
////})
//.AddNegotiate();

//builder.Services.AddAuthorization(options =>
//{
//    options.FallbackPolicy = options.DefaultPolicy;
//});

builder.Services.AddControllers();
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();
builder.Services.AddMvc(options =>
{
    options.Filters.Add(new ProducesAttribute("application/json"));
});

builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddCors(options =>
    {
        options.AddPolicy("CorsPolicy", builder => builder
            .WithOrigins("https://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()
        );
    })
    .AddDbContext<CreatureBracketContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
    })
    .AddServices()
    .AddMapper()
    .AddSignalR();
;

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app
        .UseSwagger()
        .UseSwaggerUI();
}

app
    .UseHttpsRedirection()
    .UseAuthorization()
    .UseCors("CorsPolicy")
    .UseRouting()
    .UseEndpoints(endpoints => endpoints.MapHub<LiveHub>("/hubs/live"))
//.UseAuthentication()
;

app.MapControllers();

app.Run();
