using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using learnRazor.Data;
using learnRazor.Interfaces;
using learnRazor.Repostories;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
// Add services to the container.
builder.Services.AddHttpLogging(o => { });
builder.Services.AddLogging(config =>
{
    config.AddConsole();
    config.AddDebug();
    // Other logging providers
});
// builder.Services.AddLogging();
builder.Services.AddRazorPages();

var database = "D";
builder.Services.AddDbContext<AppDbContext>(options =>
{
    if (database.Equals("P"))
        options.UseSqlServer(builder.Configuration.GetConnectionString("devSQLSERVERDb"));
    else if(database.Equals("D"))
        options.UseSqlite(builder.Configuration.GetConnectionString("devSQLiteDb"));
});
builder.Services.AddScoped<IMovieRepository,MovieRepository>();
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    services.InitSeedData();
}
// app.UseHttpLogging();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseDeveloperExceptionPage();
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();