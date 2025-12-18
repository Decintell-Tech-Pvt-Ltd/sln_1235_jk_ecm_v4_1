
using Serilog;
using Serilog.Events;
using wa_1235_jk_ecm_v4.CustomExceptionMiddleware;
using wa_1235_jk_ecm_v4.CustomMiddleware;
using wa_1235_jk_ecm_v4.Interface;
using wa_1235_jk_ecm_v4.Models.DecintellCommon;
using wa_1235_jk_ecm_v4.Repository;

var builder = WebApplication.CreateBuilder(args);

//#region Serilog Configuration
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .WriteTo.Console(LogEventLevel.Information)
    .CreateLogger();
builder.Host.UseSerilog();
//#endregion

// Add services to the container
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddHttpContextAccessor();

// Session configuration
var randomGuid = Guid.NewGuid().ToString();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(20);
    options.Cookie.IsEssential = true;
    options.Cookie.Name = $".wa_1235_jk_ecm_v4.Session";
    options.Cookie.Domain = builder.Configuration["Decintell:DomainName"];
    options.Cookie.HttpOnly = true;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
});
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSingleton<IAppSettingsService, AppSettingsService>();
builder.Services.Configure<DecintellSettings>(builder.Configuration.GetSection("Decintell"));
builder.Services.Configure<DecintellSettings>(builder.Configuration.GetSection("DecintellData"));
builder.Services.AddHttpClient();



builder.Services.AddSingleton<IGenericMethods, GenericMethodsRepository>();
builder.Services.AddSingleton<ILogServices, LogManagerRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// ? Enable session middleware BEFORE any custom middleware or authorization
app.UseSession();

// ? Global exception handler
app.ConfigureCustomExceptionMiddleware();

// ? Custom middleware (e.g., logs session)
app.UseMiddleware<SessionLoggingMiddleware>();

// ? Now do authorization
app.UseAuthorization();

app.MapBlazorHub();
app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
