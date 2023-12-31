using KaleGroup.Business.Business;
using KaleGroup.Business.IBusiness;
using KaleGroup.DataAccess.Context;
using KaleGroup.DataAccess.Repository.Files.Command;
using KaleGroup.DataAccess.Repository.Files.Interface;
using KaleGroup.DataAccess.Repository.Menu.Command;
using KaleGroup.DataAccess.Repository.Pages.Command;
using KaleGroup.DataAccess.Repository.Pages.Interface;
using KaleGroup.DataAccess.Repository.Slider.Command;
using KaleGroup.DataAccess.Repository.Slider.Interface;
using KaleGroup.DataAccess.Repository.SubMenu.Interface;
using KaleGroup.DataAccess.Repository.User.Command;
using KaleGroup.DataAccess.Repository.User.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BaseContext>(options => options.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=kalegroup;MultipleActiveResultSets=true;Integrated Security=True; TrustServerCertificate=True"));
 
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IUserLogic, UserLogic>();
builder.Services.AddTransient<IMenuLogic, MenuLogic>();
builder.Services.AddTransient<ISubMenuLogic, SubMenuLogic>();
builder.Services.AddTransient<IUploadFileLogic, UploadFileLogic>();
builder.Services.AddTransient<IWebPagesLogic, WebPagesLogic>();
builder.Services.AddTransient<ISliderLogic, SliderLogic>();


builder.Services.AddTransient(typeof(KaleGroup.DataAccess.Abstract.IRepository<>), typeof(KaleGroup.DataAccess.Abstract.Repository<>));
builder.Services.AddTransient<IMenuRepository, MenuRepository>();
builder.Services.AddTransient<ISubMenuRepository, SubMenuRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUploadFilesRepository, UploadFilesRepository>();
builder.Services.AddTransient<IWebPagesRepository, WebPagesRepository>();
builder.Services.AddTransient<ISliderRepository, SliderRepository>();
builder.Services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();


builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddSession();

var app = builder.Build();

 
app.UseSession();

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
app.UseCookiePolicy();

  
app.Run();
 