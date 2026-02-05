using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MVC_Assignment.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MVC_AssignmentContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MVC_AssignmentContext") ?? throw new InvalidOperationException("Connection string 'MVC_AssignmentContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<MVC_Assignment.Filters.AboutActionLogFilter>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
    
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<MVC_AssignmentContext>();
    context.Database.EnsureCreated();
}
app.Run();
