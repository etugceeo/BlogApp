using BlogApp.Data.Concrete.EfCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BlogContext>(
    options =>
    {
        //options.UseSqlite("data Source=blog.db"); this code may be too
        var config = builder.Configuration;
        var connectionString = config.GetConnectionString("mysql_connection");
        //options.UseSqlite(connectionString); when ı use sqllite
        var version = new MySqlServerVersion(new Version(8, 4, 6));
        options.UseMySql(connectionString, version);
    }
);
var app = builder.Build();
SeedData.TestVerileriniDoldur(app);
app.MapGet("/", () => "Hello World!");

app.Run();
