using Microsoft.EntityFrameworkCore;
using WebThucHanh.Models;
using WebThucHanh.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var constr = builder.Configuration.GetConnectionString("QlBanVaLiContext");
builder.Services.AddDbContext<QlbanVaLiContext>(x=>x.UseSqlServer(constr));
builder.Services.AddScoped<ILoaiSpRepository, LoaiSpRepository>();

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
