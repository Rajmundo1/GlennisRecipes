using Autofac;
using Autofac.Extensions.DependencyInjection;
using GlennisRecipes.BLL;
using GlennisRecipes.DAL;
using GlennisRecipes.Infrastructure.Services;
using GlennisRecipes.Model.Entities;
using GlennisRecipes.Model.Interfaces;
using GlennisRecipes.Shared;
using IdentityModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Serilog.Events;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.UseSerilog((hostingContext, loggerConfiguration) =>
{
    loggerConfiguration
        .ReadFrom.Configuration(hostingContext.Configuration)
        .Enrich.FromLogContext()
        .WriteTo.Console();
});
builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new BLLModule());
    builder.RegisterModule(new DALModule());
});

builder.Services.AddAutoMapper(typeof(MapperProfiles));

//builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("GlennisRecipesDb")));
builder.Services.AddDbContext<ApplicationDbContext>();

//builder.Services.AddScoped<DbContext, ApplicationDbContext>();
builder.Services.AddScoped<IUserStore<User>, ApplicationUserStore>();
builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    //TODO: strenghten password requirements
    //options.Password.RequiredLength = 8;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
})
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer("Normal", cfg =>
    {
        cfg.RequireHttpsMetadata = false;
        cfg.SaveToken = true;
        cfg.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration.GetSection("Authentication")["JwtNormal"],
            ValidateAudience = true,
            ValidAudience = builder.Configuration.GetSection("Authentication")["JwtNormal"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("Authentication")["JwtKey"])),
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero // remove delay of token when expire
        };
    });

builder.Services
    .AddAuthorization(options =>
    {
        options.AddPolicy("RequireLogin", new AuthorizationPolicyBuilder()
            .RequireAuthenticatedUser()
            .AddAuthenticationSchemes("Normal")
            .RequireClaim(JwtClaimTypes.Role, "Normal")
            .Build());
    });

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IIdentityService, IdentityService>();
builder.Services.AddSingleton<ICommonHelper, CommonHelper>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSerilogRequestLogging(options =>
{
    // Customize the message template
    options.MessageTemplate = "Handled {RequestPath}";

    // Emit debug-level events instead of the defaults
    options.GetLevel = (httpContext, elapsed, ex) => LogEventLevel.Debug;

    // Attach additional properties to the request completion event
    options.EnrichDiagnosticContext = (diagnosticContext, httpContext) =>
    {
        diagnosticContext.Set("RequestHost", httpContext.Request.Host.Value);
        diagnosticContext.Set("RequestScheme", httpContext.Request.Scheme);
    };

});

app.UseHttpsRedirection();
//app.UseStaticFiles(new StaticFileOptions
//{
//    FileProvider = new PhysicalFileProvider(
//    Path.Combine(builder.Environment.ContentRootPath, "wwwroot/images")),
//    RequestPath = "/images"
//});
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
