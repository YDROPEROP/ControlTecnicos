using Microsoft.EntityFrameworkCore;
using ControlTecnicos.DAL.DataContext;
using ControlTecnicos.DAL.Repository;
using ControlTecnicos.Models;
using ControlTecnicos.BLL.Servicios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DBTecnicosContext>(options =>
{
options.UseSqlServer(builder.Configuration.GetConnectionString("CadenaSQL"));
});

builder.Services.AddScoped<IGenericRepository<Sucursal>, SucarsalRepository>();
builder.Services.AddScoped<IGenericRepository<Elemento>, ElementoRepository>();
builder.Services.AddScoped<IGenericRepository<Tecnico>, TecnicoRepository>();
builder.Services.AddScoped<IGenericRepository<ElementosTecnico>, ElementosTecnicoRepository>();

builder.Services.AddScoped<ISucursalService, SucursalService>();
builder.Services.AddScoped<IElementoService, ElementoService>();
builder.Services.AddScoped<ITecnicoService, TecnicoService>();
builder.Services.AddScoped<IElementosTecnicoService, ElementosTecnicoService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
