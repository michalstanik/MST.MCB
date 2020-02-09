using AutoMapper;
using MCB.Business.CoreHelper.Attributes;
using MCB.Business.CoreHelper.UserInterfaces;
using MCB.Business.Models.Flights;
using MCB.Data.RepositoriesInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MCB.Api.Controllers
{
    [Route("api/flights/")]
    [Produces("application/json")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private readonly IFlightRepository _repository;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;
        private readonly IUserInfoService _userInfoService;

        public FlightsController(IFlightRepository repository, IMapper mapper, LinkGenerator linkGenerator,
            IUserInfoService userInfoService)
        {
            _repository = repository;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
            _userInfoService = userInfoService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/vnd.mcb.flight+json")]
        [RequestHeaderMatchesMediaType("Accept",
            "application/json",
            "application/vnd.mcb.flight+json")]
        public async Task<ActionResult<FlightModel>> GetFlight(int id)
        {
            return await GetSpecificFlight<FlightModel>(id);
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/vnd.mcb.flightfull+json")]
        [RequestHeaderMatchesMediaType("Accept", "application/vnd.mcb.flightfull+json")]
        public async Task<ActionResult<List<FlightModelFull>>> GetFlights()
        {
            var flightsFromRepo = await _repository.GetFligtsForUser(_userInfoService.UserId);

            return Ok(_mapper.Map<List<FlightModelFull>>(flightsFromRepo));
        }

        private async Task<ActionResult<T>> GetSpecificFlight<T>(int flightId) where T : class
        {
            var flightFromRepo = await _repository.GetFlight(flightId);

            if (flightFromRepo == null)
            {
                return BadRequest();
            }

            if (_userInfoService.Role == "Administrator")
            {
                return Ok(_mapper.Map<T>(flightFromRepo));
            }

            var userPermissionToTheTrip = await _repository.CheckUserPermissionsForFlight(flightId, _userInfoService.UserId);

            if (userPermissionToTheTrip != true && _userInfoService.Role != "Administrator")
            {
                return Forbid();
            }

            return Ok(_mapper.Map<T>(flightFromRepo));
        }
    }
}
