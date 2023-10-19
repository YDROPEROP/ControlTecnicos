using ControlTecnicos.BLL.Servicios;
using ControlTecnicos.DAL.DataContext;
using ControlTecnicos.DAL.Repository;
using ControlTecnicos.Models.DTOs;
using Microsoft.EntityFrameworkCore;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigions";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                      });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DBTecnicosContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CadenaSQL"));
});

builder.Services.AddScoped<IGenericRepository<SucursalDTO>, SucarsalRepository>();
builder.Services.AddScoped<IGenericRepository<ElementoDTO>, ElementoRepository>();
builder.Services.AddScoped<IGenericRepository<TecnicoDTO>, TecnicoRepository>();
builder.Services.AddScoped<IElementosTecnicoRepository, ElementosTecnicoRepository>();

builder.Services.AddScoped<ISucursalService, SucursalService>();
builder.Services.AddScoped<IElementoService, ElementoService>();
builder.Services.AddScoped<ITecnicoService, TecnicoService>();
builder.Services.AddScoped<IElementosTecnicoService, ElementosTecnicoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
