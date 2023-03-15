using Microsoft.Extensions.Logging;
using ToDoAppDB.Services;
using ToDoAppDB.ViewModels;
using CommunityToolkit.Maui;

namespace ToDoAppDB;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif
        builder.Services.AddSingleton<Views.ToDoPage>();
        builder.Services.AddSingleton<ToDoPageViewModel>();

        builder.Services.AddTransient<Views.DetailsPage>();
        builder.Services.AddTransient<DetailsPageViewModel>();

        builder.Services.AddTransient<Views.AddPage>();
        builder.Services.AddTransient<AddPageViewModel>();

        builder.Services.AddSingleton<DbConnection>();

        return builder.Build();
    }
}