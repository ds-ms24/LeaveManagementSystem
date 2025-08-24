using LeaveManagementSystem.Application;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

DataServicesRegistration.AddDataServices(builder.Services, builder.Configuration);
ApplicationServicesRegistration.AddApplicationServices(builder.Services);

builder.Host.UseSerilog((ctx, config) =>
    config.WriteTo.Console()
    .ReadFrom.Configuration(ctx.Configuration)
);

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminSupervisorOnly", policy =>
    {
        policy.RequireRole(Roles.Administrator, Roles.Supervisor);
    });
});

builder.Services.AddHttpContextAccessor();

builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
    options.Password.RequiredLength = 8;
})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Middleware
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
// the default routing configuration is looking at the pattern where the controller is going to have a name and then we look for that action.
// Index is set to default homepage template
// dont touch this if you dont need to
app.MapRazorPages();

app.Run();
