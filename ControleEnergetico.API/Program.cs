using Abstractions;
using Data;
using Microsoft.EntityFrameworkCore;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<EnergiaContext>(op => op.UseInMemoryDatabase("testDb"));
builder.Services
    .AddScoped<IFotovoltaicoCalculoService,
    FotovoltaicoCalculoService>();

builder.Services.AddCors(x => x.AddDefaultPolicy(bld => bld
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin()));

builder.Services
    .AddScoped<IAerogeradoresCalculoService,
    AerogeradoresCalculoService>();

builder.Services
    .AddScoped<IBiodigestorCalculoService,
    BiodigestorCalculoService>();

builder.Services
    .AddScoped<ICustoEnergeticoCalculatorService,
    CustoEnergeticoCalculatorService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

using var serviceScope = app.Services.GetService<IServiceScopeFactory>()?.CreateScope();

if (serviceScope == null)
    return;

var context = serviceScope.ServiceProvider.GetRequiredService<EnergiaContext>();
await context.PopulateDatabase();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors();
app.UseAuthorization();

app.MapControllers();

app.Run();