using Library_Group.Objects;
using Library_Group.Service;
using Microsoft.EntityFrameworkCore;

namespace Library_Group
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

            builder.Services.AddControllers();

            builder.Services.AddTransient<BookService>();
            builder.Services.AddTransient<AuthorService>();
            builder.Services.AddTransient<CategoryService>();

            string connectionString = builder.Configuration.GetConnectionString("mySqlConnectionString");

            builder.Services.AddDbContext<DatabaseContext>(option => option.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

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
            app.MapControllers();

            app.Run();
        }
    }
}
