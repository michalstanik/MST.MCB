using AutoMapper;
using MCB.Business.CoreHelper.Attributes;
using MCB.Business.CoreHelper.UserInterfaces;
using MCB.Business.Models.Trips;
using MCB.Data.RepositoriesInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MCB.Api.Controllers
{
    [Route("api/trips/")]
    [Produces("application/json")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        private readonly ITripRepository _repository;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;
        private readonly IUserInfoService _userInfoService;

        public TripsController(ITripRepository repository, IMapper mapper, LinkGenerator linkGenerator,
            IUserInfoService userInfoService)
        {
            _repository = repository;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
            _userInfoService = userInfoService;
        }

        /// <summary>
        /// Get an Trip by id
        /// </summary>
        /// <param name="id">Id of the Trip</param>
        /// <returns>An Trip based on the MediaType</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/vnd.mcb.trip+json")]
        [RequestHeaderMatchesMediaType("Accept", new[] {
            "application/json",
            "application/vnd.mcb.trip+json" })]
        public async Task<ActionResult<TripModel>> GetTrip(int id)
        {
            return await GetSpecificTrip<TripModel>(id);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/vnd.mcb.tripfull+json")]
        [RequestHeaderMatchesMediaType("Accept", new[] { "application/vnd.mcb.tripfull+json" })]
        public async Task<ActionResult<TripFullModel>> GetTripFull(int id)
        {
            return await GetSpecificTrip<TripFullModel>(id, true, true);
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/vnd.mcb.trip+json")]
        [RequestHeaderMatchesMediaType("Accept", new[] {
            "application/json",
            "application/vnd.mcb.trip+json" })]
        public async Task<ActionResult<List<TripModel>>> GetTrips()
        {
            return await GetListOfTrips<TripModel>();
        }
         
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/vnd.mcb.tripwithstops+json")]
        [RequestHeaderMatchesMediaType("Accept", new[] { "application/vnd.mcb.tripwithstops+json" })]
        public async Task<ActionResult<TripWithStopsModel>> GetTripWithStops(int id)
        {
            return await GetSpecificTrip<TripWithStopsModel>(id, true);
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/vnd.mcb.tripwithstops+json")]
        [RequestHeaderMatchesMediaType("Accept", new[] { "application/vnd.mcb.tripwithstops+json" })]
        public async Task<ActionResult<List<TripWithStopsModel>>> GetTripsWithStops()
        {
            return await GetListOfTrips<TripWithStopsModel>(true);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/vnd.mcb.tripwithstopsandusers+json")]
        [RequestHeaderMatchesMediaType("Accept", new[] { "application/vnd.mcb.tripwithstopsandusers+json" })]
        public async Task<ActionResult<TripWithStopsAndUsersModel>> GetTripWithStopsAndUsers(int id)
        {
            return await GetSpecificTrip<TripWithStopsAndUsersModel>(id, true, true);
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/vnd.mcb.tripwithstopsandusers+json")]
        [RequestHeaderMatchesMediaType("Accept", new[] { "application/vnd.mcb.tripwithstopsandusers+json" })]
        public async Task<ActionResult<List<TripWithStopsAndUsersModel>>> GetTripsWithStopsAndUsers()
        {
            return await GetListOfTrips<TripWithStopsAndUsersModel>(true, true);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/vnd.mcb.tripwithcountries+json")]
        [RequestHeaderMatchesMediaType("Accept", new[] { "application/vnd.mcb.tripwithcountries+json" })]
        public async Task<ActionResult<TripWithCountriesModel>> GetTripWithCountries(int id)
        {
            return await GetSpecificTrip<TripWithCountriesModel>(id, true);
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/vnd.mcb.tripwithcountries+json")]
        [RequestHeaderMatchesMediaType("Accept", new[] { "application/vnd.mcb.tripwithcountries+json" })]
        public async Task<ActionResult<List<TripWithCountriesModel>>> GetTripsWithCountries(int id)
        {
            return await GetListOfTrips<TripWithCountriesModel>(true);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/vnd.mcb.tripwithcountriesandstats+json")]
        [RequestHeaderMatchesMediaType("Accept", new[] { "application/vnd.mcb.tripwithcountriesandstats+json" })]
        public async Task<ActionResult<TripWithCountriesAndStatsModel>> GetTripWithCountriesAndStats(int id)
        {
            return await GetSpecificTrip<TripWithCountriesAndStatsModel>(id, true, true);
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/vnd.mcb.tripwithcountriesandstats+json")]
        [RequestHeaderMatchesMediaType("Accept", new[] { "application/vnd.mcb.tripwithcountriesandstats+json" })]
        public async Task<ActionResult<List<TripWithCountriesAndStatsModel>>> GetTripsWithCountriesAndStats(int id)
        {
            return await GetListOfTrips<TripWithCountriesAndStatsModel>(true, true);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/vnd.mcb.tripwithcountriesandworldheritages+json")]
        [RequestHeaderMatchesMediaType("Accept", new[] { "application/vnd.mcb.tripwithcountriesandworldheritages+json" })]
        public async Task<ActionResult<TripWithCountriesAndWorldHeritagesModel>> GetTripWithCountriesAndWorldHeritages(int id)
        {
            return await GetSpecificTrip<TripWithCountriesAndWorldHeritagesModel>(id, true, true);
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/vnd.mcb.tripwithcountriesandworldheritages+json")]
        [RequestHeaderMatchesMediaType("Accept", new[] { "application/vnd.mcb.tripwithcountriesandworldheritages+json" })]
        public async Task<ActionResult<List<TripWithCountriesAndWorldHeritagesModel>>> GetTripsWithCountriesAndWorldHeritages(int id)
        {
            return await GetListOfTrips<TripWithCountriesAndWorldHeritagesModel>(true, true);
        }

        [HttpGet()]
        private async Task<ActionResult<List<T>>> GetListOfTrips<T>(bool includeStops = false, bool includeUsers = false) where T : class
        {
            var tripsFromRepo = await _repository.GetTripsByUser(_userInfoService.UserId,includeStops, includeUsers);

            if (tripsFromRepo == null)
            {
                return BadRequest();
            }

            return Ok(_mapper.Map<List<T>>(tripsFromRepo));
        }

        private async Task<ActionResult<T>> GetSpecificTrip<T>(int tripId, bool includeStops = false, bool includeUsers = false) where T : class
        {
            var tripFromRepo = await _repository.GetTrip(tripId , includeStops, includeUsers);

            if (tripFromRepo == null)
            {
                return BadRequest();
            }

            if(_userInfoService.Role == "Administrator")
            {
                return Ok(_mapper.Map<T>(tripFromRepo));
            }

            var userPermissionToTheTrip = await _repository.CheckUserPermissionsForTrip(tripId, _userInfoService.UserId);

            if(userPermissionToTheTrip != true && _userInfoService.Role != "Administrator")
            {
                return Forbid();
            }

            return Ok(_mapper.Map<T>(tripFromRepo));
        }
    }
}
