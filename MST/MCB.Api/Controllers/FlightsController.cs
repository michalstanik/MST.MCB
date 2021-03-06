﻿using AutoMapper;
using MCB.Business.CoreHelper.Attributes;
using MCB.Business.CoreHelper.ResourceParameters;
using MCB.Business.CoreHelper.UserInterfaces;
using MCB.Business.Models.Flights;
using MCB.Data.RepositoriesInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Collections.Generic;
using System.Linq;
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

        /// <summary>
        /// Get an Flight by id
        /// </summary>
        /// <param name="id">Id of the Flight</param>
        /// <returns>An Flight based on the MediaType</returns>
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

        /// <summary>
        /// Get a list of Flights
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/vnd.mcb.flight+json")]
        [RequestHeaderMatchesMediaType("Accept", "application/vnd.mcb.flight+json")]
        public async Task<ActionResult<List<FlightModel>>> GetFlights(
            [FromQuery] FlightsResourceParameters flightsResourceParameters)
        {
            var flightsFromRepo = await _repository.GetFligtsForUser(_userInfoService.UserId, flightsResourceParameters);

            return Ok(_mapper.Map<List<FlightModel>>(flightsFromRepo));
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/vnd.mcb.flightfull+json")]
        [RequestHeaderMatchesMediaType("Accept", "application/vnd.mcb.flightfull+json")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<ActionResult<List<FlightModelFull>>> GetFlightsFull(
            [FromQuery] FlightsResourceParameters flightsResourceParameters)
        {
            var flightsFromRepo = await _repository.GetFligtsForUser(_userInfoService.UserId, flightsResourceParameters);

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

            var userPermissionToTheTrip = flightFromRepo.UserFlights.Where(u => u.TUserId == _userInfoService.UserId).FirstOrDefault();

            if (userPermissionToTheTrip == null && _userInfoService.Role != "Administrator")
            {
                return Forbid();
            }

            return Ok(_mapper.Map<T>(flightFromRepo));
        }
    }
}
