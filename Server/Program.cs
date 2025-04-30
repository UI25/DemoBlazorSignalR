using BlazorSignalR.Server.Data;
using BlazorSignalR.Server.Hubs;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;


builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

#region SignalR 
builder.Services.AddSignalR();
builder.Services.AddResponseCompression(opts =>
{
    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
        new[] { "application/octet-stream" });
});
#endregion

#region DB Setting
builder.Services.AddDbContext<BooksDbContext>(opts =>
{
    opts.UseSqlServer(configuration.GetConnectionString("BookDB"), m =>
    m.MigrationsAssembly("BlazorSignalR.Server"));
});
#endregion



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();


app.UseRouting();
app.UseBlazorFrameworkFiles();

app.MapRazorPages();
app.MapControllers();

app.MapHub<BroadcastHub>("/hubs/broadcasthub");
app.MapFallbackToFile("index.html");

app.Run();
