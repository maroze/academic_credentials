using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebParking.Data.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// получаем строку подключени€ из файла конфигурации
string connection = builder.Configuration.GetConnectionString("DefaultConnection");

// добавл€ем контекст в качестве сервиса в приложение
builder.Services.AddDbContext<ParkingContext>(options => options.UseNpgsql(connection));

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
// получение по умолчанию данных
app.MapGet("/", (ParkingContext db) => db.Users.ToList());

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
