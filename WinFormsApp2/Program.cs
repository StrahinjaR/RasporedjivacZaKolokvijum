using Microsoft.Extensions.DependencyInjection;
using Shared.Interfaces;
using Business_Layer;
using Data_Layer.Repository;

namespace WinFormsApp2
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
             ApplicationConfiguration.Initialize();
            // Application.Run(new Form1()) ;
            var services = new ServiceCollection();
            ConfigureServices(services);
            using (ServiceProvider servicesProvider = services.BuildServiceProvider())
            {
                var form = servicesProvider.GetRequiredService<Form1>();
                var form11 = servicesProvider.GetRequiredService<Prozor3>();
                Application.Run(form);
               
              

            }
        }
        public static void ConfigureServices(ServiceCollection services)
        {
            services.AddScoped<IBiznisStudent, StudentBusiness>();
            services.AddScoped<IBiznisPredmet, PredmetBusiness>();
            services.AddScoped<IBiznisUcionica, UcionicaBusiness>();
            services.AddScoped<IBiznisUpisani, UpisanPredmetBusiness>();

            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IUcionicaRepository, UcionicaRepository>();
            services.AddScoped<IUpisaniPredmetiRepository, UpisaniPredmetiRepository>();
            services.AddScoped<IPredmetRepository, PredmetRepository>();

            services.AddScoped<Form1>();
            services.AddScoped<Prozor3>();
        }

    }
}