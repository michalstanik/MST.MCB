using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MST.IDP.Admin.Configuration.Constants;
using Skoruba.IdentityServer4.Admin.BusinessLogic.Dtos.Log;
using Skoruba.IdentityServer4.Admin.BusinessLogic.Services.Interfaces;
using System.Threading.Tasks;

namespace MST.IDP.Admin.Controllers
{
    [Authorize(Policy = AuthorizationConsts.AdministrationPolicy)]
    public class LogController : BaseController
    {
        private readonly ILogService _logService;

        public LogController(ILogService logService,
            ILogger<ConfigurationController> logger) : base(logger)
        {
            _logService = logService;
        }

        [HttpGet]
        public async Task<IActionResult> ErrorsLog(int? page, string search)
        {
            ViewBag.Search = search;
            var logs = await _logService.GetLogsAsync(search, page ?? 1);

            return View(logs);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
#pragma warning disable MVC1004 // Rename model bound parameter.
        public async Task<IActionResult> DeleteLogs(LogsDto logs)
#pragma warning restore MVC1004 // Rename model bound parameter.
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(ErrorsLog), logs);
            }

            await _logService.DeleteLogsOlderThanAsync(logs.DeleteOlderThan.Value);

            return RedirectToAction(nameof(ErrorsLog));
        }
    }
}