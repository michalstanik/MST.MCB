using MCB.Business.CoreHelper.Attributes;
using MCB.Business.CoreHelper.UserInterfaces;
using MCB.Business.Models.Stats;
using MCB.Data.RepositoriesInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MCB.Api.Controllers
{
    [Route("api/stats/")]
    [Produces("application/json")]
    [ApiController]
    public class StatsController : ControllerBase  
    {
        private readonly IUserInfoService _userInfoService;
        private readonly IStatsRepository _statsRepository;

        public StatsController(IUserInfoService userInfoService, IStatsRepository statsRepository)
        {
            _userInfoService = userInfoService;
            _statsRepository = statsRepository;
        }

        /// <summary>
        /// Get an UserStats by authenticated user
        /// </summary>
        /// <returns>An Stats based on the MediaType</returns>
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/vnd.mcb.basestats+json")]
        [RequestHeaderMatchesMediaType("Accept",
            "application/json",
            "application/vnd.mcb.basestats+json")]
        public ActionResult<StatsModel> GetBaseStats()
        {
            var statsToBeReturn = new StatsModel();

            statsToBeReturn.TripsStats.TripsCount = _statsRepository.GetTripsCountForUser(_userInfoService.UserId);

            statsToBeReturn.FlightsStats.FlightsCount = _statsRepository.GetFlightsCountForUser(_userInfoService.UserId);
            statsToBeReturn.FlightsStats.FligtsDistance = _statsRepository.GetFlightsDistanceForUser(_userInfoService.UserId);
            statsToBeReturn.FlightsStats.FlightsTime = _statsRepository.GetFlightsTimeForUser(_userInfoService.UserId);

            statsToBeReturn.CountriesStats.VisitedCountriesCount = _statsRepository.GetCountriesForUser(_userInfoService.UserId);

            return  Ok(statsToBeReturn); 
        }
    }
}
