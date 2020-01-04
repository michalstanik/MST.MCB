using AutoMapper;
using MCB.Business.CoreHelper.Attributes;
using MCB.Business.CoreHelper.UserInterfaces;
using MCB.Business.Models.Geo;
using MCB.Data.RepositoriesInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MCB.Api.Controllers
{
    [Route("api/country/")]
    [Produces("application/json")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ITripRepository _tripRepository;
        private readonly ICountryRepository _geoRepository;
        private readonly IMapper _mapper;
        private readonly IUserInfoService _userInfoService;

        public CountriesController(ITripRepository tripRepository,
            ICountryRepository geoRepository,
            IMapper mapper,
            IUserInfoService userInfoService)
        {
            _tripRepository = tripRepository;
            _geoRepository = geoRepository;
            _mapper = mapper;
            _userInfoService = userInfoService;
        }

        /// <summary>
        /// Get a list of Countries
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/vnd.mcb.countriesforUserWithAssessments+json")]
        [RequestHeaderMatchesMediaType("Accept",
            "application/json",
            "application/vnd.mcb.countriesforUserWithAssessments+json"
        )]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<CountryModelWithAssesments>>> GetCountriesForUserWithAssessments()
        {
            try
            {
                var results = await _geoRepository.GetCountiresWithAssesmentForUser(_userInfoService.UserId);
                var mapped = _mapper.Map<List<CountryModelWithAssesments>>(results);


                Dictionary<string, long> UserAssesment = await _geoRepository.GetCountireAssesmentForUser(_userInfoService.UserId);

                foreach (var item in mapped)
                {
                    if (UserAssesment.ContainsKey(item.Alpha2Code))
                    {
                        item.AreaLevelAssessment = UserAssesment.GetValueOrDefault(item.Alpha2Code);
                    }
                    else
                    {
                        item.AreaLevelAssessment = 0;
                    }
                }

                return mapped;

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}