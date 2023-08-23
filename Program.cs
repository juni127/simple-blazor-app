using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MatBlazor;
using Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme; //standard cookie auth
    options.DefaultChallengeScheme = CustomDefaults.AuthenticationScheme; //custom remote auth
})
.AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
.AddRemoteScheme<CustomOptions, CustomHandler>(CustomDefaults.AuthenticationScheme, "Custom", options =>
{
    options.AuthorizationEndpoint = "http://localhost"; // remote endpoint
    options.CallbackPath = "/aasdasda"; // local callback endpoint
});

// Add MatBlazor service to the
builder.Services.AddMatBlazor();

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseAuthentication();
app.UseAuthorization();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
// app.MapRazorPages();

app.Run();
