using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GrpcExample.Client.GrpcClients;
using GrpcExample.Client.Models;

namespace GrpcExample.Client.Controllers
{
	[ApiController]
	[Route("cards")]
	public class CardsController : ControllerBase
	{
		private readonly ICardsClient _cardsClient;

		public CardsController(ICardsClient cardsClient)
		{
			_cardsClient = cardsClient;
		}

		[HttpPost]
		public async Task<IActionResult> CreateCardAsync([FromBody] CreateCardCommand command)
		{
			if (command == null)
			{
				return BadRequest();
			}

			var result = await _cardsClient.CreateCardAsync(command);

			return Ok(result);
		}
	}
}
