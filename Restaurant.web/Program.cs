using Microsoft.Extensions.DependencyInjection;
using Restaurant.web;
using Restaurant.web.Services;
using Restaurant.web.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddHttpClient<IProductServices, ProductService>();
SD.ProductApiBase = builder.Configuration["ServiceUrls:ProductApi"];
builder.Services.AddScoped<IProductServices, ProductService>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = "Cookies";
    options.DefaultChallengeScheme = "oidc";
}).AddCookie("Cookies", c => c.ExpireTimeSpan = TimeSpan.FromMinutes(12))
.AddOpenIdConnect("oidc", options =>
{
    options.Authority = builder.Configuration["ServiceUrls:IdentityApi"];
    options.GetClaimsFromUserInfoEndpoint = true;
    options.ClientId = "restaurant";
    options.ClientSecret = "secretKeySecret";
    options.ResponseType = "code";
    options.TokenValidationParameters.NameClaimType = "name";
    options.TokenValidationParameters.NameClaimType = "role";
    options.Scope.Add("restaurant");
    options.SaveTokens = true;
    options.RequireHttpsMetadata = false;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
