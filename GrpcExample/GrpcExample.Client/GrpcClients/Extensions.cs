using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GrpcExample.Client.GrpcClients
{
	public static class Extensions
	{
		private const string CardsGrpcClientSectionName = "CardsGrpcClient";

		public static IServiceCollection ConfigureGrpcClients(this IServiceCollection services, IConfiguration configuration)
		{
			services.Configure<CardsGrpcClientOptions>(configuration.GetSection(CardsGrpcClientSectionName));

			services.AddSingleton<ICardsClient, CardsClient>();

			return services;
		}
	}
}
