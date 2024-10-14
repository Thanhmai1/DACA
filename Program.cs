using Microsoft.EntityFrameworkCore;
using DACA;

var builder = WebApplication.CreateBuilder(args);
string connecting_string = "Server=DESKTOP-AHDNE2G\\SQLEXPRESS;Database=myDataBase;User Id=sa;Password=123456@A; TrustServerCertificate=True";
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<EduBD_context>(options => options.UseSqlServer(connecting_string));

string connecting_string_student = "Server=DESKTOP-AHDNE2G\\SQLEXPRESS;Database=students;User Id=sa;Password=123456@A; TrustServerCertificate=True";
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<EduBD_context>(options => options.UseSqlServer(connecting_string));

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
