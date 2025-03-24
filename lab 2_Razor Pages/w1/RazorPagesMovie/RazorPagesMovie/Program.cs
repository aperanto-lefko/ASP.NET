using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;
namespace RazorPagesMovie
{
	public class Program
	{
		public static void Main(string[] args)
		{
            // Создаём "строитель" веб-приложения и загружаем конфигурацию из appsettings.json
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

                    // EnsureCreated() создаёт базу данных, если она ещё не существует
                    // В отличие от миграций, просто создаёт схему на основе текущей модели
                    // Для продакшена лучше использовать миграции (Update-Database)
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
