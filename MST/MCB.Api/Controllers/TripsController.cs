using AutoMapper;
using MCB.Business.CoreHelper.Attributes;
using MCB.Business.CoreHelper.UserInterfaces;
using MCB.Business.Models.Trips;
using MCB.Data.Domain.Trips;
using MCB.Data.RepositoriesInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using MST.Flogging.Core;
using System;
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
        [RequestHeaderMatchesMediaType("Accept",
            "application/json",
            "application/vnd.mcb.trip+json")]
        [TrackUsage("TripsController", "GetTrip", "trip")]
        public async Task<ActionResult<TripModel>> GetTrip(int id)
        {
            return await GetSpecificTrip<TripModel>(id);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/vnd.mcb.tripfull+json")]
        [TrackUsage("TripsController", "GetTrip", "tripfull")]
        [RequestHeaderMatchesMediaType("Accept", "application/vnd.mcb.tripfull+json")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<ActionResult<TripFullModel>> GetTripFull(int id)
        {
            return await GetSpecificTrip<TripFullModel>(id, true, true);
        }

        /// <summary>
        /// Get a list of Trips
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/vnd.mcb.trip+json")]
        [RequestHeaderMatchesMediaType("Accept",
            "application/json",
            "application/vnd.mcb.trip+json")]
        public async Task<ActionResult<List<TripModel>>> GetTrips()
        {
            return await GetListOfTrips<TripModel>();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/vnd.mcb.tripwithstops+json")]
        [RequestHeaderMatchesMediaType("Accept", "application/vnd.mcb.tripwithstops+json")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<ActionResult<TripWithStopsModel>> GetTripWithStops(int id)
        {
            return await GetSpecificTrip<TripWithStopsModel>(id, true);
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/vnd.mcb.tripwithstops+json")]
        [RequestHeaderMatchesMediaType("Accept", "application/vnd.mcb.tripwithstops+json")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<ActionResult<List<TripWithStopsModel>>> GetTripsWithStops()
        {
            return await GetListOfTrips<TripWithStopsModel>(true);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/vnd.mcb.tripwithstopsandusers+json")]
        [RequestHeaderMatchesMediaType("Accept", "application/vnd.mcb.tripwithstopsandusers+json")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<ActionResult<TripWithStopsAndUsersModel>> GetTripWithStopsAndUsers(int id)
        {
            return await GetSpecificTrip<TripWithStopsAndUsersModel>(id, true, true);
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/vnd.mcb.tripwithstopsandusers+json")]
        [RequestHeaderMatchesMediaType("Accept", "application/vnd.mcb.tripwithstopsandusers+json")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<ActionResult<List<TripWithStopsAndUsersModel>>> GetTripsWithStopsAndUsers()
        {
            return await GetListOfTrips<TripWithStopsAndUsersModel>(true, true);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/vnd.mcb.tripwithcountries+json")]
        [RequestHeaderMatchesMediaType("Accept", "application/vnd.mcb.tripwithcountries+json")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<ActionResult<TripWithCountriesModel>> GetTripWithCountries(int id)
        {
            return await GetSpecificTrip<TripWithCountriesModel>(id, true);
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/vnd.mcb.tripwithcountries+json")]
        [RequestHeaderMatchesMediaType("Accept", "application/vnd.mcb.tripwithcountries+json")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<ActionResult<List<TripWithCountriesModel>>> GetTripsWithCountries()
        {
            return await GetListOfTrips<TripWithCountriesModel>(true);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/vnd.mcb.tripwithcountriesandstats+json")]
        [RequestHeaderMatchesMediaType("Accept", "application/vnd.mcb.tripwithcountriesandstats+json")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<ActionResult<TripWithCountriesAndStatsModel>> GetTripWithCountriesAndStats(int id)
        {
            return await GetSpecificTrip<TripWithCountriesAndStatsModel>(id, true, true);
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/vnd.mcb.tripwithcountriesandstats+json")]
        [RequestHeaderMatchesMediaType("Accept", "application/vnd.mcb.tripwithcountriesandstats+json")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<ActionResult<List<TripWithCountriesAndStatsModel>>> GetTripsWithCountriesAndStats()
        {
            return await GetListOfTrips<TripWithCountriesAndStatsModel>(true, true, true);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/vnd.mcb.tripwithcountriesandworldheritages+json")]
        [RequestHeaderMatchesMediaType("Accept", "application/vnd.mcb.tripwithcountriesandworldheritages+json")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<ActionResult<TripWithCountriesAndWorldHeritagesModel>> GetTripWithCountriesAndWorldHeritages(int id)
        {
            return await GetSpecificTrip<TripWithCountriesAndWorldHeritagesModel>(id, true, true);
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/vnd.mcb.tripwithcountriesandworldheritages+json")]
        [RequestHeaderMatchesMediaType("Accept", "application/vnd.mcb.tripwithcountriesandworldheritages+json")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<ActionResult<List<TripWithCountriesAndWorldHeritagesModel>>> GetTripsWithCountriesAndWorldHeritages()
        {
            return await GetListOfTrips<TripWithCountriesAndWorldHeritagesModel>(true, true);
        }

        /// <summary>
        /// Add new Trip
        /// </summary>
        /// <param name="trip">Trip object</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Consumes("application/vnd.mcb.tripforcreation+json")]
        [RequestHeaderMatchesMediaType("Content-Type",
            "application/json",
            "application/vnd.mcb.tripforcreation+json"
        )]
        public async Task<IActionResult> AddTrip([FromBody] TripModelForCreation trip)
        {
            if (trip == null) return BadRequest();

            // validation of the DTO happens here

            return await AddSpecificTrip(trip);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Consumes("application/vnd.mcb.tripwithstopsforcreation+json")]
        [RequestHeaderMatchesMediaType("Content-Type", "application/vnd.mcb.tripwithstopsforcreation+json")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> AddTripWithStops([FromBody] TripWithStopsModelForCreation trip)
        {
            if (trip == null) return BadRequest();

            // validation of the DTO happens here

            return await AddSpecificTrip(trip);
        }

        [HttpGet()]
        private async Task<ActionResult<List<T>>> GetListOfTrips<T>(bool includeStops = false, bool includeUsers = false, bool includeFlights = false) where T : class
        {
            List<Trip> tripsFromRepo = await _repository.GetTripsByUser(_userInfoService.UserId, includeStops, includeUsers, includeFlights);

            if (tripsFromRepo == null)
            {
                return BadRequest();
            }

            return Ok(_mapper.Map<List<T>>(tripsFromRepo));
        }

        private async Task<ActionResult<T>> GetSpecificTrip<T>(int tripId, bool includeStops = false, bool includeUsers = false) where T : class
        {
            var tripFromRepo = await _repository.GetTrip(tripId, includeStops, includeUsers);

            if (tripFromRepo == null)
            {
                return BadRequest();
            }

            if (_userInfoService.Role == "Administrator")
            {
                return Ok(_mapper.Map<T>(tripFromRepo));
            }

            var userPermissionToTheTrip = await _repository.CheckUserPermissionsForTrip(tripId, _userInfoService.UserId);

            if (userPermissionToTheTrip != true && _userInfoService.Role != "Administrator")
            {
                return Forbid();
            }

            return Ok(_mapper.Map<T>(tripFromRepo));
        }

        private async Task<IActionResult> AddSpecificTrip<T>(T trip)
            where T : class
        {
            var tripEntity = _mapper.Map<Trip>(trip);

            await _repository.AddTrip(tripEntity);

            if (!await _repository.SaveChangesAsync())
            {
                throw new Exception("Adding a trip failed on save.");
            }

            await _repository.AddUserToTheTrip(tripEntity.Id, _userInfoService.UserId);

            if (!await _repository.SaveChangesAsync())
            {
                throw new Exception("Adding a user to the trip failed on save.");
            }

            var tripToReturn = _mapper.Map<Trip>(tripEntity);

            return Created("", tripToReturn);
        }
    }
}
