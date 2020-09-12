using System.Threading.Tasks;
using GrpcExample.CardsService.Models;
using MongoDB.Driver;

namespace GrpcExample.CardsService.Repositories
{
	public class CardsRepository : ICardsRepository
	{
		private readonly IMongoDatabase _database;

		public CardsRepository(IMongoDatabase database)
		{
			_database = database;
		}

		protected IMongoCollection<Card> Collection => _database.GetCollection<Card>(nameof(Card));

		public async Task ReplaceCardAsync(Card card)
		{
			await Collection.ReplaceOneAsync(e => e.Id.Equals(card.Id), card, new ReplaceOptions
			{
				IsUpsert = true
			});
		}
	}
}
