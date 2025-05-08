using Microsoft.AspNetCore.Identity;
using System;
using Microsoft.EntityFrameworkCore;
using StudentLoginReg.Data;
using StudentLoginReg.Models.StudentInfo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddIdentity<Student,IdentityRole>(option =>
{
    option.Password.RequireNonAlphanumeric = false;
    option.Password.RequiredLength = 8;
    option.Password.RequireUppercase = false;
    option.Password.RequireLowercase = true;
    option.User.RequireUniqueEmail = true;
    option.SignIn.RequireConfirmedAccount = false;
    option.SignIn.RequireConfirmedEmail = false;
    option.SignIn.RequireConfirmedPhoneNumber = false;


}).AddRoles<IdentityRole>()
 .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
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

using (var scope = app.Services.CreateAsyncScope())
{
    var roleManager = scope.ServiceProvider.GetService<RoleManager<IdentityRole>>();
    var roles = new[] { "Admin", "Manager", "Member" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));

        }
    }
}
using (var scope = app.Services.CreateAsyncScope())
{
    var userManager =
        scope.ServiceProvider.GetService<UserManager<Student>>();
    string email = "admin@admin.com";
    string password = "Test@123";
    if (await userManager.FindByEmailAsync(email) == null)
    {
        var user = new Student();
        user.UserName = email;
        user.Email = email;
        await userManager.CreateAsync(user, password);
        await userManager.AddToRoleAsync(user, "Admin");
    }
    
}

app.Run();