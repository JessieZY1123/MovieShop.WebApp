using MovieShop.ApplicationCore.Contracts.Repository;
using MovieShop.ApplicationCore.Contracts.Services;
using MovieShop.Infrastructure.Data;
using MovieShop.Infrastructure.Repository;
using MovieShop.Infrastructure.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddSqlServer<MovieDbContext>(builder.Configuration.GetConnectionString("MovieShop"));

builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<ICastRepository, CastRepository>();


builder.Services.AddScoped<ICastService, CastService>();
builder.Services.AddScoped<IMovieService, MovieService>();


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
