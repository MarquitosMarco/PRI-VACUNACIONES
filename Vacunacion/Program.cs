using Microsoft.EntityFrameworkCore;
using Vacunacion.Data;

var builder = WebApplication.CreateBuilder(args);

// Configura la cadena de conexión desde appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Agrega el DbContext a los servicios de la aplicación
builder.Services.AddDbContext<DB_Context>(options =>
{
    options.UseSqlServer(connectionString);
});

// Agrega el servicio de sesiones
builder.Services.AddSession();

builder.Services.AddControllersWithViews();

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

// Agrega el uso de sesiones
app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
