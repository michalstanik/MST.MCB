using AutoMapper;
using MCB.Business.CoreHelper.Attributes;
using MCB.Business.CoreHelper.UserInterfaces;
using MCB.Business.Models.Geo;
using MCB.Data.RepositoriesInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MST.Flogging.Core.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MCB.Api.Controllers
{
    [Route("api/continent/")]
    [Produces("application/json")]
    [ApiController]
    public class ContinentsController : ControllerBase
    {
        private readonly ITripRepository _tripRepository;
        private readonly ICountryRepository _geoRepository;
        private readonly IMapper _mapper;
        private readonly IUserInfoService _userInfoService;

        public ContinentsController(ITripRepository tripRepository,
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
        /// Get list of Continents
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [LogUsage("ContinentsController/GetContinentsWithRegionsAndCountriesForUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/vnd.mcb.continentWithRegionsAndCountries+json")]
        [RequestHeaderMatchesMediaType("Accept",
            "applicaion/json",
            "application/vnd.mcb.continentWithRegionsAndCountries+json"
        )]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<ContinentWithRegionsAndCountriesModel>>> GetContinentsWithRegionsAndCountriesForUser()
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
    }
}