using System.Threading.Tasks;
using Grpc.Core;
using GrpcExample.CardsService.Models;
using GrpcExample.CardsService.Repositories;

namespace GrpcExample.CardsService.Services
{
	public class CardsService : Cards.CardsService.CardsServiceBase
	{
		private readonly ICardsRepository _cardsRepository;

		public CardsService(ICardsRepository cardsRepository)
		{
			_cardsRepository = cardsRepository;
		}

		public override async Task<Cards.CardResponse> CreateCard(Cards.CreateCardRequest request, ServerCallContext context)
		{
			var card = Card.FromGrpcRequest(request);
			await _cardsRepository.ReplaceCardAsync(card);
			var response = card.ToGrpcResponse();
			return response;
		}
	}
}
