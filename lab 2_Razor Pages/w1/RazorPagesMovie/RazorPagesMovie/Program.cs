using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;
namespace RazorPagesMovie
{
	public class Program
	{
		public static void Main(string[] args)
		{
            /*var builder = WebApplication.CreateBuilder(args);
			builder.Services.AddDbContext<RazorPagesMovieContext>(options =>
			    options.UseSqlite(builder.Configuration.GetConnectionString("RazorPagesMovieContext") ?? throw new InvalidOperationException("Connection string 'RazorPagesMovieContext' not found.")));

			// Add services to the container.
			builder.Services.AddRazorPages();

			var app = builder.Build();
			*/

            var builder = WebApplication.CreateBuilder(args);

            // Добавление контекста базы данных
            builder.Services.AddDbContext<RazorPagesMovieContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("RazorPagesMovieContext")
                    ?? throw new InvalidOperationException("Connection string 'RazorPagesMovieContext' not found.")));

            // Добавление сервисов Razor Pages
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Инициализация базы данных (заполнение тестовыми данными)
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<RazorPagesMovieContext>();
                    context.Database.EnsureCreated(); // Создаёт БД, если её нет (аналог Update-Database)
                    SeedData.Initialize(services);    // Заполняет данными
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "Ошибка при заполнении базы данных.");
                }
            }
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
		}
	}
}
