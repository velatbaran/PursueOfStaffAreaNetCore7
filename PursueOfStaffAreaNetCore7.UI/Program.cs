using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PursueOfStaffAreaNetCore7.BusinnessLayer.Abstract;
using PursueOfStaffAreaNetCore7.BusinnessLayer.Concrete;
using PursueOfStaffAreaNetCore7.BusinnessLayer.Mapping;
using PursueOfStaffAreaNetCore7.DataAccessLayer.Abstract;
using PursueOfStaffAreaNetCore7.DataAccessLayer.Concrete;
using PursueOfStaffAreaNetCore7.DataAccessLayer.DataContext;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddDbContext<DatabaseContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), opts =>
    {
        opts.MigrationsAssembly(Assembly.GetAssembly(typeof(DatabaseContext)).GetName().Name);
    });
    opts.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

builder.Services.AddAutoMapper(typeof(MapProfile));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));
builder.Services.AddScoped<IStaffRepository,StaffRepository>();
builder.Services.AddScoped<IStaffService,StaffService>();
builder.Services.AddScoped<IAreaRepository, AreaRepositoy>();
builder.Services.AddScoped<IAreaService, AreaService>();
builder.Services.AddScoped<IDutyAssignRepository, DutyAssignRepository>();
builder.Services.AddScoped<IDutyAssignService, DutyAssginService>();
builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();


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
