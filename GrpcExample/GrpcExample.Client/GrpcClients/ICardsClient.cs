using System.Threading.Tasks;
using GrpcExample.Client.Models;

namespace GrpcExample.Client.GrpcClients
{
	public interface ICardsClient
	{
		Task<CardResponse> CreateCardAsync(CreateCardCommand command);
	}
}
