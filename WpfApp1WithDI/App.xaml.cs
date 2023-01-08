using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Text;
using System.Windows;

namespace WpfApp1WithDI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; set; }
        public IConfiguration Configuration { get; set; }

        private void ConfigureServices(ServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IPage1ViewModel, Page1ViewModel>();
            serviceCollection.AddTransient(typeof(MainWindow));

            serviceCollection.AddTransient<Home>();
            serviceCollection.AddTransient<Page1>();
            serviceCollection.AddTransient<Page2>();
            serviceCollection.AddSingleton<Func<Page1>>(serviceProvider => serviceProvider.GetService<Page1>);
            serviceCollection.AddSingleton<Func<Page2>>(serviceProvider => serviceProvider.GetService<Page2>);

        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true);

            Configuration = builder.Build();

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            ServiceProvider = serviceCollection.BuildServiceProvider();
            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
    }
}
