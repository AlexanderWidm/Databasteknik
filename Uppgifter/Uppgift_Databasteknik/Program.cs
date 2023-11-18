using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Uppgift_Databasteknik.Contexts;
using Uppgift_Databasteknik.Menus;
using Uppgift_Databasteknik.Repositories;
using Uppgift_Databasteknik.Services;

namespace Uppgift_Databasteknik
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var services = new ServiceCollection();

            services.AddDbContext<DataContext>(options => options.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Alexander\source\repos\Uppgifter\Uppgift_Databasteknik\Contexts\assignment_database.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True"));

            // Repositories
            services.AddScoped<AddressRepository>();
            services.AddScoped<CustomerRepository>();
            services.AddScoped<ProductCategoryRepository>();
            services.AddScoped<ProductRepository>();
            services.AddScoped<PricingUnitRepository>();

            // Services
            services.AddScoped<CustomerService>();
            services.AddScoped<ProductService>();

            // Menus
            services.AddScoped<MainMenu>();
            services.AddScoped<CustomerMenu>();
            services.AddScoped<ProductMenu>();

            
            var sp = services.BuildServiceProvider();
            var mainMenu = sp.GetRequiredService<MainMenu>();
            await mainMenu.StartAsync();
        }
    }
}
