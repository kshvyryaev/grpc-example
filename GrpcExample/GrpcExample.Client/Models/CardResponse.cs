using System;

namespace GrpcExample.Client.Models
{
	public class CardResponse
	{
		public string Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public DateTime CreationDate { get; set; }

		public static CardResponse FromGrpcResponse(Cards.CardResponse response)
		{
			var result = new CardResponse
			{
				Id = response.Id,
				Name = response.Name,
				Description = response.Description,
				CreationDate = response.CreationDate.ToDateTime()
			};

			return result;
		}
	}
}
