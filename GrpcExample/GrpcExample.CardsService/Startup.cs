using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GrpcExample.CardsService.Repositories;

namespace GrpcExample.CardsService
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddGrpc();

			services.ConfigureRepositories(Configuration);
		}

		public void Configure(IApplicationBuilder app)
		{
			app.UseRouting();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapGrpcService<Services.CardsService>();
			});
		}
	}
}
