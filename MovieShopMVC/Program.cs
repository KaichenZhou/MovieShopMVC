using ApplicationCore.Contracts.Services;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using ApplicationCore.Contracts.Repository;
using Infrastructure.Repository;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using MovieShopMVC.Services;


//using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//DI is first class citizen in .Net Core
//older .Net framework DI was not builtin,we have to rely on 3rd party libraries
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<ICastService, CastService>();
builder.Services.AddScoped<ICastRepository, CastRepository>();
builder.Services.AddScoped<IRepository<Genre>, Repository<Genre>>();
builder.Services.AddScoped<IGenreService,GenreService>();
builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<ICurrentLogedInUser, CurrentLogedInUser>();


//inject httpContext for IHttpContextAccessor interface
builder.Services.AddHttpContextAccessor();

//builder.Services.AddScoped<IMovieService, MovieTestService>();

//Inject the connection string into Dbcontext option constructor
// get the connection string from app settings

builder.Services.AddDbContext<MovieShopDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MovieShopDbConnection"));
});

//set cookie based authentication info
//Cookie, JWT
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(
        options =>
        {
            //settings for cookie
            options.Cookie.Name = "MovieShopAuthCookie";
            options.ExpireTimeSpan = TimeSpan.FromHours(2);
            options.LoginPath = "/account/login";

        }
        
    );

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

//Authentication Middleware
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
