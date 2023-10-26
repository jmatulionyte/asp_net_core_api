using asp_net_core_rest_api;
using asp_net_core_rest_api.Data;
using asp_net_core_rest_api.Logging;
using asp_net_core_rest_api.Repository;
using asp_net_core_rest_api.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Log.Logger = new LoggerConfiguration().MinimumLevel.Debug()
//    .WriteTo.File("log/villaLogs.txt", rollingInterval: RollingInterval.Infinite).CreateLogger();

//builder.Host.UseSerilog();

//add database connection
var connectionString = builder.Configuration.GetConnectionString("DefaultSQLConnection");

//providing connection to ApplicationDbContextClass
builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseSqlServer(connectionString);
});

//registrig as dependency injection/service?
builder.Services.AddScoped<IVillaRepository, VillaRepository>();
builder.Services.AddScoped<IVillaNumberRepository, VillaNumberRepository>();

//mapper for model-dto mapping
builder.Services.AddAutoMapper(typeof(MappingConfig));

builder.Services.AddControllers(option =>
{
    //option.ReturnHttpNotAcceptable = true;
}).AddNewtonsoftJson().AddXmlDataContractSerializerFormatters();
// Learn more about configuring Swagger/OpenAP I at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//custom logger service
//builder.Services.AddSingleton<ILogging, LoggingV2>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

