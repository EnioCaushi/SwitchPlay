using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SwitchPlay.Data;
using SwitchPlay.Models;
using SwitchPlay.Services;

namespace SwitchPlay.Controllers
{
    [Authorize]
    public class PlatformController : Controller
    {
        public IActionResult GetPlatformCount()
        {
            int platformCount = _context.Platforms.Count();
            return new JsonResult(platformCount);
        }
        private readonly SwitchPlayContext _context;
        private readonly IPlatformService _platformService;

        public PlatformController(IPlatformService platformService, SwitchPlayContext context)
        {
            _platformService = platformService;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var platforms = await _platformService.GetAllPlatformsAsync();
            return View(platforms);
        }

    }
}
