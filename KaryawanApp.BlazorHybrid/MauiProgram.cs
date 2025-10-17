using KaryawanApp.BlazorHybrid.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace KaryawanApp.BlazorHybrid;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddMauiBlazorWebView();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

        builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        // REGISTER HttpClient (wajib!)
        // Registrasi HttpClient
        builder.Services.AddSingleton(sp =>
        {
            var opt = sp.GetRequiredService<IOptions<ApiOptions>>().Value;
            var raw = string.IsNullOrWhiteSpace(opt.BaseUrl) ? "http://localhost:5000/" : opt.BaseUrl;
            if (!Uri.TryCreate(raw, UriKind.Absolute, out var baseUri))
                throw new InvalidOperationException($"Invalid Api BaseUrl: '{raw}'");
            return new HttpClient { BaseAddress = baseUri };
        });

        // REGISTER service kamu
        builder.Services.AddScoped<KaryawanService>();


        return builder.Build();
	}
}
