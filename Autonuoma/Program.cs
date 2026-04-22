namespace Lab_2_DB;

using System.Collections.Concurrent;
using NLog;


public class Program {
	Logger log = LogManager.GetCurrentClassLogger();

	private static void ConfigureLogging()
	{
		var config = new NLog.Config.LoggingConfiguration();

		var console =
			new NLog.Targets.ConsoleTarget("console")
			{
				Layout = @"${date:format=HH\:mm\:ss}|${level}| ${message} ${exception}"
			};
		config.AddTarget(console);
		config.AddRuleForAllLevels(console);

		LogManager.Configuration = config;
	}

	public static void Main(string[] args)
	{
		ConfigureLogging();

		var self = new Program();
		self.Run(args);
	}

	private void Run(string[] args)
	{
		try
		{
			var builder = WebApplication.CreateBuilder(args);
			var appPort = builder.Configuration.GetValue<int?>("AppPort") ?? 5001;

			builder.WebHost.ConfigureKestrel(opts =>
			{
				opts.Listen(System.Net.IPAddress.Loopback, appPort);
			});

			builder.Services
				.AddRazorPages()
				.AddRazorOptions(opts => {
					opts.ViewLocationFormats.Add("/Views/{0}.cshtml");
				});

			var app = builder.Build();

			Config.CreateSingletonInstance(app.Configuration);

			app.Use(async (context, next) =>
			{
				context.Items["HttpRequestID"] = Guid.NewGuid().ToString();

				context.Response.Headers.CacheControl = 
					#pragma warning disable CA1861
					new [] { 
						"no-store, no-cache, must-revalidate, max-age=0", 
						"post-check=0, pre-check=0" 
					};
					#pragma warning restore CA1861
				context.Response.Headers.Pragma = "no-cache";

				await next();
			});

			app.UseStaticFiles();
			app.UseRouting();
			app.UseAuthorization();

			app.UseRequestLocalization(opts =>
			{
				opts.AddSupportedCultures(["lt-LT", "en-US"]);
				opts.AddSupportedUICultures(["lt-LT", "en-US"]);
				opts.SetDefaultCulture("lt-LT");
			});

			app.MapDefaultControllerRoute();
			app.MapRazorPages();

			app.Run();
		}
		catch( Exception e )
		{
			log.Error(e, "Unhandled exception caught when initializing program. The main thread is now dead.");
		}
	}
}




