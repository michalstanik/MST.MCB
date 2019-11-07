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
    [Route("api/geo/")]
    [Produces("application/json")]
    [ApiController]
    public class GeoController : ControllerBase
    {
        private readonly ITripRepository _tripRepository;
        private readonly IGeoRepository _geoRepository;
        private readonly IMapper _mapper;
        private readonly IUserInfoService _userInfoService;

        public GeoController(ITripRepository tripRepository,
            IGeoRepository geoRepository,
            IMapper mapper,
            IUserInfoService userInfoService)
        {
            _tripRepository = tripRepository;
            _geoRepository = geoRepository;
            _mapper = mapper;
            _userInfoService = userInfoService;
        }

        /// <summary>
        /// Get list of one of Geo entity type
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/vnd.mcb.cintinentWithRegionsAndCountries+json")]
        [RequestHeaderMatchesMediaType("Accept", new[] { "application/vnd.mcb.cintinentWithRegionsAndCountries+json" })]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<ContinentWithRegionsAndCountriesModel>>> GetContinentsWithRegionsAndCountriesForUser()
        {
            try
            {
                var continentsFromRepo = await _geoRepository.GetContinents(true, false);
                var mappedContinents
                        = _mapper.Map<List<ContinentWithRegionsAndCountriesModel>>(continentsFromRepo);

                var userCountries = await _geoRepository.GetCountiresWithAssesmentForUser(_userInfoService.UserId);
                var mappedUserCountries =
                    _mapper.Map<List<CountryModel>>(userCountries);

                foreach (var userCountry in mappedUserCountries)
                {
                    foreach (var item in mappedContinents)
                    {
                        foreach (var region in item.Regions)
                        {
                            if (region.Name == userCountry.RegionName)
                            {
                                region.Countries.Add(userCountry);
                                region.VisitedCountryCount += 1;
                                item.VisitetCountriesOnContinent += 1;
                            }
                        }
                    }
                }

                return mappedContinents;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/vnd.mcb.countriesforUserWithAssessments+json")]
        [RequestHeaderMatchesMediaType("Accept", new[] { "application/vnd.mcb.countriesforUserWithAssessments+json" })]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ApiExplorerSettings(IgnoreApi = true)]
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