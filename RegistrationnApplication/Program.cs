using Microsoft.EntityFrameworkCore;
using RegistrationnApplication.Data;
using RegistrationnApplication.Repositories.Interface;
using RegistrationnApplication.Repositories.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(optons=>optons.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IRegistrationRepositorycs, RegistrationRepository>();
builder.Services.AddScoped<ICountryRepositroy, CountryRepositroy>();
builder.Services.AddScoped<IStateRepository, StateRepositorycs>();

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
    pattern: "{controller=Registration}/{action=Index}/{id?}");

app.Run();
