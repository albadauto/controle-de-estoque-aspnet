using ControleDeEstoque.Context;
using ControleDeEstoque.Repository;
using ControleDeEstoque.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
string connection = builder.Configuration.GetConnectionString("Database");
builder.Services.AddEntityFrameworkSqlServer().AddDbContext<DatabaseContext>(o => o.UseSqlServer(connection));
builder.Services.AddScoped<IEstoque, EstoqueRepository>();
builder.Services.AddScoped<ILogin, LoginRepository>();
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
