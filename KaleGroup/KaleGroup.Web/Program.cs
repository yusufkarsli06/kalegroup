using KaleGroup.Business.Business;
using KaleGroup.Business.IBusiness;
using KaleGroup.DataAccess.Context;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddDbContext<BaseContext>(options => options.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=kalegroup;MultipleActiveResultSets=true;Integrated Security=True; TrustServerCertificate=True"));
 

//builder.Services.AddControllersWithViews();
//builder.Services.AddTransient<IUserLogic, UserLogic>();


//builder.Services.AddScoped(typeof(KaleGroup.DataAccess.Abstract.IRepository<>), typeof(KaleGroup.DataAccess.Abstract.Repository<>));
//builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();


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
