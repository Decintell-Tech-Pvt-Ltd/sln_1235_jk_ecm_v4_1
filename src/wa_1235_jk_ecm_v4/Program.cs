using Serilog;
using Serilog.Events;
using wa_1235_jk_ecm_v4.CustomExceptionMiddleware;
using wa_1235_jk_ecm_v4.CustomMiddleware;
using wa_1235_jk_ecm_v4.Interface;
using wa_1235_jk_ecm_v4.Models.DecintellCommon;
using wa_1235_jk_ecm_v4.Repository;

var builder = WebApplication.CreateBuilder(args);

// ----------------------------------------------------
// Serilog Configuration
// ----------------------------------------------------
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .WriteTo.Console(LogEventLevel.Information)
    .CreateLogger();

builder.Host.UseSerilog();

// ----------------------------------------------------
// Add services to the container
// ----------------------------------------------------
builder.Services.AddControllersWithViews()
    .AddJsonOptions(options =>
    {
        // READ ? case-insensitive (UserId, userId, USERID)
        options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;

        // WRITE ? camelCase JSON
        options.JsonSerializerOptions.PropertyNamingPolicy =
            System.Text.Json.JsonNamingPolicy.CamelCase;

        options.JsonSerializerOptions.DictionaryKeyPolicy =
            System.Text.Json.JsonNamingPolicy.CamelCase;
    });

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddHttpContextAccessor();

// ----------------------------------------------------
// Session configuration
// ----------------------------------------------------
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(20);
    options.Cookie.IsEssential = true;
    options.Cookie.Name = ".wa_1235_jk_ecm_v4.Session";
    options.Cookie.Domain = builder.Configuration["Decintell:DomainName"];
    options.Cookie.HttpOnly = true;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
});

// ----------------------------------------------------
// Dependency Injection
// ----------------------------------------------------
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSingleton<IAppSettingsService, AppSettingsService>();

builder.Services.Configure<DecintellSettings>(
    builder.Configuration.GetSection("Decintell"));

builder.Services.Configure<DecintellSettings>(
    builder.Configuration.GetSection("DecintellData"));

builder.Services.AddHttpClient();

builder.Services.AddSingleton<IGenericMethods, GenericMethodsRepository>();
builder.Services.AddSingleton<ILogServices, LogManagerRepository>();

// ----------------------------------------------------
// Build app
// ----------------------------------------------------
var app = builder.Build();

// ----------------------------------------------------
// Configure HTTP request pipeline
// ----------------------------------------------------
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// IMPORTANT: Session BEFORE custom middleware
app.UseSession();

// Global exception middleware
app.ConfigureCustomExceptionMiddleware();

// Custom session logging middleware
app.UseMiddleware<SessionLoggingMiddleware>();

app.UseAuthorization();

// ----------------------------------------------------
// Endpoints
// ----------------------------------------------------
app.MapBlazorHub();
app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
