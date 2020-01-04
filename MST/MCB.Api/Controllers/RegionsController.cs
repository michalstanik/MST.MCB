using AutoMapper;
using MCB.Business.CoreHelper.Attributes;
using MCB.Business.CoreHelper.UserInterfaces;
using MCB.Business.Models.Geo;
using MCB.Data.RepositoriesInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace MCB.Api.Controllers
{
    [Route("api/regions/")]
    [Produces("application/json")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionRepository _regionRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;
        private readonly IUserInfoService _userInfoService;

        public RegionsController(IRegionRepository regionRepository, ICountryRepository countryRepository,
            IMapper mapper, LinkGenerator linkGenerator,
            IUserInfoService userInfoService)
        {
            _regionRepository = regionRepository;
            _countryRepository = countryRepository;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
            _userInfoService = userInfoService;
        }

        /// <summary>
        /// Get an Region by id
        /// </summary>
        /// <param name="id">Id of the Region</param>
        /// <returns>An Region based on the MediaType</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/vnd.mcb.region+json")]
        [RequestHeaderMatchesMediaType("Accept",
            "application/json",
            "application/vnd.mcb.region+json")]
        public async Task<ActionResult<RegionModel>> GetRegion(int id)
        {
            return await GetSpecificRegion<RegionModel>(id);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/vnd.mcb.regionwithuservisits+json")]
        [RequestHeaderMatchesMediaType("Accept",
            "application/vnd.mcb.regionwithuservisits+json")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<ActionResult<RegionModelWithCountriesAndUserVisits>> GetRegionWithUserVisits(int id)
        {
            var regionFromRepo = await _regionRepository.GetRegion(id);

            if (regionFromRepo == null)
            {
                return BadRequest();
            }

            var regionMappedToModel = _mapper.Map<RegionModelWithCountriesAndUserVisits>(regionFromRepo);

            var userAssesmentFromRepo = await _countryRepository.GetCountireAssesmentForUser(_userInfoService.UserId);

            foreach (var country in regionMappedToModel.Countries)
            {
                if (userAssesmentFromRepo.Where(c => c.Key == country.Alpha2Code.ToUpper(CultureInfo.CurrentCulture)).Any())
                {
                    country.AreaLevelAssessment = userAssesmentFromRepo.Where(c => c.Key == country.Alpha2Code.ToUpper(CultureInfo.CurrentCulture))
                        .Select(c => c.Value).SingleOrDefault();
                }
            }

            return regionMappedToModel;
        }

        private async Task<ActionResult<T>> GetSpecificRegion<T>(int regionId) where T : class
        {
            var regionFromRepo = await _regionRepository.GetRegion(regionId);

            if (regionFromRepo == null)
            {
                return BadRequest();
            }

            return Ok(_mapper.Map<T>(regionFromRepo));
        }
    }
}
