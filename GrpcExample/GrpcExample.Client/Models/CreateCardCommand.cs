namespace GrpcExample.Client.Models
{
	public class CreateCardCommand
	{
		public string Name { get; set; }

		public string Description { get; set; }

		public Cards.CreateCardRequest ToGrpcRequest()
		{
			var result = new Cards.CreateCardRequest
			{
				Name = Name,
				Description = Description
			};

			return result;
		}
	}
}
