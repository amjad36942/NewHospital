using MailKit;
using Microsoft.EntityFrameworkCore;
using MiniHospitalProject.Configuration;
using MiniHospitalProject.Data;
using MiniHospitalProject.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MiniHospitalProjectContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MiniHospitalProjectContext") ?? throw new InvalidOperationException("Connection string 'MiniHospitalProjectContext' not found.")));
builder.Services.AddTransient<MiniHospitalProject.Services.IMailService, MiniHospitalProject.Services.MailService>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));

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
    pattern: "{controller=UserLogins}/{action=MainPage}/{id?}");

app.Run();
