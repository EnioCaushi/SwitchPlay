using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SwitchPlay.Data;
using SwitchPlay.Repositories;
using SwitchPlay.Services;
using Microsoft.AspNetCore.Builder;
using System;
using SwitchPlay.Identity;
using Microsoft.AspNetCore.Http.Features;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<SwitchPlayContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SwitchPlayContext") ?? throw new InvalidOperationException("Connection string not found")));

builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<SwitchPlayContext>().AddDefaultTokenProviders();

// Add services to the container.
builder.Services.AddDistributedMemoryCache();
builder.Services.AddMemoryCache();
builder.Services.AddSession(x => { x.IdleTimeout = TimeSpan.FromDays(10); x.Cookie.HttpOnly = true; x.Cookie.IsEssential = true; });
builder.Services.AddHttpClient();
builder.Services.AddAuthorization();
builder.Services.AddCors(x => x.AddPolicy("AllowAnyOrigin", x => x.AllowAnyOrigin()));
builder.Services.Configure<FormOptions>(x => x.ValueCountLimit = 10000);
builder.Services.AddControllersWithViews();






builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<CategeoryRepository>();
builder.Services.AddScoped<PlatformRepository>();
builder.Services.AddScoped<StudioRepository>();
builder.Services.AddScoped<GameRepository>();
builder.Services.AddScoped<StudioCategoryRepositories>();
builder.Services.AddScoped<GameCategoryRepository>();
builder.Services.AddScoped<GamePlatformRepository>();

builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IRoleService, RoleService>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<IPlatformService, PlatformService>();
builder.Services.AddTransient<IStudioService, StudioService>();
builder.Services.AddTransient<IGameService, GameService>();
builder.Services.AddTransient<IFileHandleService, FileHandleService>();
builder.Services.AddTransient<IStudioCategoryService, StudioCategoryService>();
builder.Services.AddTransient<IGameCategoryService, GameCategoryService>();
builder.Services.AddTransient<IGamePlatformService, GamePlatformService>();




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


app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
