using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using WaXercise.Data;
using WaXercise.Services;
using WaXercise.Services.Interfaces;

var allowSpecificOrigins = "allowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<WaXerciseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WaXerciseContext") ?? throw new InvalidOperationException("Connection string 'WaXerciseContext' not found.")));

//Ajout des services de base
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowSpecificOrigins,
        policyBuilder =>
        {
            policyBuilder
            .WithOrigins(builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>())
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
        });
});

// Add services to the container.
builder.Services.AddControllers()
        .AddNewtonsoftJson(options =>
        {
            //options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        });
;

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IPeopleService, PeopleService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(allowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
