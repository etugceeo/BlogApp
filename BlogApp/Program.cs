using BlogApp.Data.Abstract;
using BlogApp.Data.Concrete.EfCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();// to relate controllers and views each other
builder.Services.AddDbContext<BlogContext>(
    options =>
    {
        options.UseSqlite(builder.Configuration["ConnectionStrings:Sql_connection"]);
        //options.UseSqlite("data Source=blog.db"); this code may be too
        /*var config = builder.Configuration;
        var connectionString = config.GetConnectionString("sql_connection");
        options.UseSqlite(connectionString); 
        */
        /*var version = new MySqlServerVersion(new Version(8, 4, 6));
        options.UseMySql(connectionString, version);*/
    }
);
builder.Services.AddScoped<IPostRepository,EfPostRepository>();
builder.Services.AddScoped<ITagRepository,EfTagRepository>();
var app = builder.Build();
app.UseStaticFiles();
SeedData.TestVerileriniDoldur(app);
app.MapDefaultControllerRoute();
app.Run();
