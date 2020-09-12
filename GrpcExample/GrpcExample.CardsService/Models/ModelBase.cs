using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GrpcExample.CardsService.Models
{
	public class ModelBase
	{
		[BsonId]
		public ObjectId Id { get; set; }
	}
}
