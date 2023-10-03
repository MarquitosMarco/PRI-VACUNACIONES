using Camera.MAUI;
using Microsoft.Extensions.Logging;
using PRI_Vacunaciones.Services;
namespace PRI_Vacunaciones
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCameraView()//extension para el uso de la camara
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            //Esto es para acceder a nuestro servicio o para que utilicemos
            builder.Services.AddSingleton<IPerson, Person>();
            builder.Services.AddTransient<Info_Pet>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}