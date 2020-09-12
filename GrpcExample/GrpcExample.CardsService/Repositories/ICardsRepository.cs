using System.Threading.Tasks;
using GrpcExample.CardsService.Models;

namespace GrpcExample.CardsService.Repositories
{
	public interface ICardsRepository
	{
		Task ReplaceCardAsync(Card card);
	}
}
