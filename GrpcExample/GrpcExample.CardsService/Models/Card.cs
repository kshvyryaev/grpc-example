using System;
using Google.Protobuf.WellKnownTypes;
using MongoDB.Bson;

namespace GrpcExample.CardsService.Models
{
	public class Card : ModelBase
	{
		public string Name { get; set; }

		public string Description { get; set; }

		public DateTime CreationDate { get; set; }

		public Cards.CardResponse ToGrpcResponse()
		{
			var result = new Cards.CardResponse
			{
				Id = Id.ToString(),
				Name = Name,
				Description = Description,
				CreationDate = Timestamp.FromDateTime(CreationDate)
			};

			return result;
		}

		public static Card FromGrpcRequest(Cards.CreateCardRequest request)
		{
			var result = new Card
			{
				Id = ObjectId.GenerateNewId(),
				Name = request.Name,
				Description = request.Description,
				CreationDate = DateTime.UtcNow
			};

			return result;
		}
	}
}
