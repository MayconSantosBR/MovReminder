using MovReminder.Data.Contexts;
using MovReminder.Data.Repositories;
using MovReminder.Data.Repositories.Interfaces;
using MovReminder.Models.Mappers;
using MovReminder.Services;
using MovReminder.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();

builder.Services.AddDbContext<MovreminderContext>();

builder.Services.AddAutoMapper(typeof(MapperService));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IWatchedRepository, WatchedRepository>();
builder.Services.AddScoped<IDirectorRepository, DirectorRepository>();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();

builder.Services.AddScoped<IGeneralService, GeneralService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}");

app.Run();
