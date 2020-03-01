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
    [Route("api/country/dictionary/")]
    [Produces("application/json")]
    [ApiController]
    public partial class CountriesDictionaryController : ControllerBase
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IUserInfoService _userInfoService;
        private readonly IMapper _mapper;

        public CountriesDictionaryController(ICountryRepository countryRepository,
            IUserInfoService userInfoService,
            IMapper mapper) 
        {
            _countryRepository = countryRepository;
            _userInfoService = userInfoService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get a list of Countries Dictionary
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/vnd.mcb.allCountriesWithUserAssessment+json")]
        [RequestHeaderMatchesMediaType("Accept",
            "application/json",
            "application/vnd.mcb.allCountriesWithUserAssessment+json"
        )]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<CountryModelWithAssesments>>> GetAllCountriesWithUserAssessment()
        {
            try
            {
                var results = await _countryRepository.GetCountries();
                var mapped = _mapper.Map<List<CountryModelWithAssesments>>(results);


                Dictionary<string, long> UserAssesment = await _countryRepository.GetCountireAssesmentForUser(_userInfoService.UserId);

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
                throw;
            }
        }
    }
}
