using bizland.business.Exceptions;
using bizland.business.Services.Interfaces;
using bizland.core.Models;
using Microsoft.AspNetCore.Mvc;

namespace bizland.MVC.Areas.manage.Controllers
{
    [Area("manage")]
    public class TeamController : Controller
    {
        private readonly ITeamMemberService _teamMemberService;

        public TeamController(ITeamMemberService teamMemberService)
        {
            _teamMemberService = teamMemberService;
        }
        public async Task<IActionResult> Index()
        {
            var teammembers=await _teamMemberService.GetAllAsync();
            return View(teammembers);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>Create(TeamMember teamMember)
        {
           if(!ModelState.IsValid)
            {
                return View(teamMember);
            }
            try
            {
                await _teamMemberService.CreateAsync(teamMember);
            }
            catch (ImageContentException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }
            catch(InvalidImageSizeException ex)
            {
                ModelState.AddModelError(ex.PropertyName,ex.Message);
                return View();
            }
            
            return RedirectToAction("index");
        }
    }
}
