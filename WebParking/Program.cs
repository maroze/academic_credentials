using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebParking.Data.Data;
using WebParking.Data.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// �������� ������ ����������� �� ����� ������������
string connection = builder.Configuration.GetConnectionString("DefaultConnection");

// ��������� �������� � �������� ������� � ����������
builder.Services.AddDbContext<ParkingContext>(options => options.UseNpgsql(connection));

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

// ��������� ������
app.MapGet("/parking/users", async (ParkingContext db) => await db.Users.ToListAsync());

//��������� ������ �� id
app.MapGet("/parking/users/{id:int}", async (int id, ParkingContext db) =>
{
    // �������� ������������ �� id
    UserEntityModel? user = await db.Users.FirstOrDefaultAsync(u => u.Id == id);

    // ���� �� ������, ���������� ��������� ��� � ��������� �� ������
    if (user == null) return Results.NotFound(new { message = "������������ �� ������" });

    // ���� ������������ ������, ���������� ���
    return Results.Json(user);
});

//�������� 
app.MapDelete("/parking/users/{id:int}", async (int id, ParkingContext db) =>
{
    // �������� ������������ �� id
    UserEntityModel? user = await db.Users.FirstOrDefaultAsync(u => u.Id == id);

    // ���� �� ������, ���������� ��������� ��� � ��������� �� ������
    if (user == null) return Results.NotFound(new { message = "������������ �� ������" });

    // ���� ������������ ������, ������� ���
    db.Users.Remove(user);
    await db.SaveChangesAsync();
    return Results.Json(user);
});

app.MapPost("/parking/users}", async (UserEntityModel user, ParkingContext db) =>
{
    //��������� ������������
    db.Users.Add(user);
    await db.SaveChangesAsync();
    return user;
});

app.MapPut("/parking/users/", async (UserEntityModel userData, ParkingContext db) =>
{
    // �������� ������������ �� id
    var user = await db.Users.FirstOrDefaultAsync(u => u.Id == userData.Id);

    // ���� �� ������, ���������� ��������� ��� � ��������� �� ������
    if (user == null) return Results.NotFound(new { message = "������������ �� ������" });

    // ���� ������������ ������, �������� ��� ������ � ���������� ������� �������
    user.Email = userData.Email;
    user.Password = userData.Password;
    user.Name = userData.Name;
    await db.SaveChangesAsync();
    return Results.Json(user);
});

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
