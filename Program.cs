using Microsoft.EntityFrameworkCore;
using mtuci_labs;
using mtuci_labs.Data;

UpdateAuth updateAuth = new UpdateAuth();
updateAuth.Update();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();


builder.Services.AddDbContext<MtuciLabsDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("MtuciLabsConnectionString")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();


