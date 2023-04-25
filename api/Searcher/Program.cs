using Searcher.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Searcher.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<SearcherContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SearcherContext") ?? throw new InvalidOperationException("Connection string 'SearcherContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var MyAllowSpecificOrigins = "http://localhost:8080";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:8080");
                      });
});

builder.Services.AddScoped<IBuscapeService, BuscapeService>();
builder.Services.AddScoped<IMercadoLivreService, MercadoLivreService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(MyAllowSpecificOrigins);

app.MapControllers();

app.Run();
