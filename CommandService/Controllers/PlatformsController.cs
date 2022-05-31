using AutoMapper;
using CommandService.Data;
using CommandService.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CommandService.Controllers
{
	[Route("api/commands/[controller]")]
	[ApiController]
	public class PlatformsController : ControllerBase
	{
		private readonly ICommandRepo _repo;
		private readonly IMapper _mapper;

		public PlatformsController(ICommandRepo repo, IMapper mapper)
		{
			_repo = repo;
			_mapper = mapper;
		}

		[HttpGet]
		public ActionResult<IEnumerable<PlatformReadDto>> GetAllPlatforms()
		{
			var platformItems = _repo.GetAllPlatforms();

			if (platformItems == null)
			{
				return NotFound();
			}
			return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platformItems));
		}

		[HttpPost]
		public ActionResult TestInboundConnection()
		{
			System.Console.WriteLine("--> Inbound POST # Command Service");

			return Ok("Inbound test of from Platforms Controller");
		}
	}
}