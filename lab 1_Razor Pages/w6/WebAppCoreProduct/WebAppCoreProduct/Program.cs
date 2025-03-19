using WebAppCoreProduct.Services;

namespace WebAppCoreProduct
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddScoped<IDiscountService, DiscountService>(); // Регистрация сервиса скидок
			builder.Services.AddScoped<IVATService, VATService>();// Регистрация сервиса НДС
			var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //Настройка middleware это компоненты, которые обрабатывают HTTP-запросы и ответы. Они выполняются в порядке их добавления.
            app.UseHttpsRedirection(); //перенаправляет HTTP-запросы на HTTPS (для безопасности)
            app.UseStaticFiles(); //позволяет обслуживать статические файлы (например, CSS, JavaScript, изображения) из папки wwwroot.
            app.UseRouting(); //включает маршрутизацию (определяет, какой код должен выполняться для конкретного URL).
            app.UseAuthorization(); // добавляет поддержку авторизации (проверка прав доступа).
            // Настройка Razor Pages
            app.MapRazorPages(); //Здесь настраиваются маршруты для Razor Pages. Это означает, что приложение будет искать страницы в папке Pages и автоматически связывать их с URL.
            app.Run();//Запускает приложение. После этого оно начинает слушать HTTP-запросы и обрабатывать их.
        }
    }
}
