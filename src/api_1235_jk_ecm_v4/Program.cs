
using System.Text;
using api_1235_jk_ecm_v4.DAL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));


builder.Services.AddControllers();

var key = Encoding.ASCII.GetBytes(builder.Configuration["JwtConfig:SecretKey"]); // Use Secrets Manager or Environment Variables for secrets

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidIssuer = builder.Configuration["JwtConfig:ValidIssuer"],
        ValidAudience = builder.Configuration["JwtConfig:ValidAudience"],
        ClockSkew = TimeSpan.FromMinutes(5) // Adjust as needed
    };
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<DBManager>();

var app = builder.Build();
// Enable authentication
app.UseAuthentication();
app.UseAuthorization();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//for logging http requests mostly used for API code -- by satish 26jul2023
app.UseSerilogRequestLogging();

app.UseHttpsRedirection();



app.MapControllers();

app.Run();
