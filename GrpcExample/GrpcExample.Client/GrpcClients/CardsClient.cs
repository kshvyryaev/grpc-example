using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Grpc.Net.Client;
using GrpcExample.Client.Models;

namespace GrpcExample.Client.GrpcClients
{
	public class CardsClient : ICardsClient
	{
		private readonly CardsGrpcClientOptions _options;

		public CardsClient(IOptions<CardsGrpcClientOptions> options)
		{
			_options = options.Value;
		}

		public async Task<CardResponse> CreateCardAsync(CreateCardCommand command)
		{
			using var channel = GrpcChannel.ForAddress(_options.Uri);
			var client = new Cards.CardsService.CardsServiceClient(channel);
			var grpcRequest = command.ToGrpcRequest();
			var grpcResponse = await client.CreateCardAsync(grpcRequest);
			var response = CardResponse.FromGrpcResponse(grpcResponse);
			return response;
		}
	}
}
