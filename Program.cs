using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddNewtonsoftJson(options => {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

Console.WriteLine(Environment.GetEnvironmentVariable("DATABASE_DATE_URL"));

builder.Services
    .AddDbContext<DatabaseContext>(options =>
        options.UseNpgsql(Environment.GetEnvironmentVariable("DATABASE_DATE_URL")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("EnableCORS", builder =>
    {
        builder
            .AllowAnyOrigin()
            .WithOrigins("http://localhost:4200", "https://date-frontend.vercel.app")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .Build();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("EnableCORS");

app.MapControllers();

app.Run();
