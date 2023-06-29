using BankAccountManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.Use(async (ctx, next) =>
{
    Log log = new Log(ctx.Request.Path);
    await next();
    log.resultStatusCode = ctx.Response.StatusCode;
    var Filepath = System.Environment.CurrentDirectory + @"\Logs\TransactionLog.txt";
    using (StreamWriter sWriter = File.AppendText(Filepath))
    {
        sWriter.WriteLine(log.ToString());
    }
});

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();