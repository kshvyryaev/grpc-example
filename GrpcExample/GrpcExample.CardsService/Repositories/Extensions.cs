using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace GrpcExample.CardsService.Repositories
{
	public static class Extensions
	{
		private const string MongoSectionName = "Mongo";

		public static IServiceCollection ConfigureRepositories(this IServiceCollection services, IConfiguration configuration)
		{
			var mongoOptions = new MongoOptions();
			configuration.GetSection(MongoSectionName).Bind(mongoOptions);
			var mongoClient = new MongoClient(mongoOptions.ConnectionString);
			var mongoDatabase = mongoClient.GetDatabase(mongoOptions.Database);
			services.AddSingleton(mongoDatabase);

			services.AddSingleton<ICardsRepository, CardsRepository>();

			return services;
		}
	}
}
