using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Serilog;
using webapi.Container;
using webapi.Helper;
using webapi.Repos.Models;
using webapi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IUserServices, UserService>();
builder.Services.AddTransient<IEtat_stockServices, Etat_tonerService>();
builder.Services.AddTransient<IbaseTonerService, BaseTonerService>();
/*builder.Services.AddDbContext<GestionTonerContext>(o =>
           o.UseSqlServer(builder.Configuration.GetConnectionString("TonerConnectionString")));*/


builder.Services.AddDbContext<GestionTonerContext>(options =>

 options.UseSqlServer(builder.Configuration.GetConnectionString("TonerConnectionString"),
     providerOptions => providerOptions.EnableRetryOnFailure(
            maxRetryCount: 10,
            maxRetryDelay: TimeSpan.FromSeconds(10),
            errorNumbersToAdd: null
        )
));

//builder.Services.AddDbContext<GestionTonerContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration["TonerConnectionString"],
//    sqlServerOptionsAction: sqlOptions =>
//    {
//        sqlOptions.EnableRetryOnFailure(
//        maxRetryCount: 5,
//        maxRetryDelay: TimeSpan.FromSeconds(30),
//        errorNumbersToAdd: null);
//    });
//});

builder.Services.AddAuthentication("BasicAuthentication").AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

//builder.Services.AddCors(p => p.AddDefaultPolicy(build =>
//{
//    build.WithOrigins("*").AllowAnyMethod().AllowAnyOrigin();
//}));

var logpath = builder.Configuration.GetSection("Logging:Logpath").Value;
var _logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .MinimumLevel.Override("microsoft", Serilog.Events.LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .WriteTo.File(logpath)
    .CreateLogger();
builder.Logging.AddSerilog(_logger);

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseDeveloperExceptionPage();
app.UseSwagger();
    app.UseSwaggerUI();
//}
app.UseCors(options =>
options.WithOrigins("http://localhost:4200")
.AllowAnyMethod()
.AllowAnyHeader());
app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
