using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.SuperAdmin;
using Application.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HelloEntrantServer.Controllers
{
    public class SuperAdminController : Controller
    {
        ISuperAdminService SuperAdminService;
        readonly ILogger<AdministratorController> _log;

        public SuperAdminController(ISuperAdminService SuperAdminService, ILogger<AdministratorController> log)
        {
            this.SuperAdminService = SuperAdminService;
            this._log = log;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "SuperAdmin")]
        public ActionResult CreateUniversity()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUniversity(AddUniRequest request)
        {
            if (request != null)
            {
                await SuperAdminService.AddNewUniversity(request).ConfigureAwait(true);
                _log.LogInformation("Created University");
                return RedirectToAction("ManageUniversities", "SuperAdmin");
            }

            return RedirectToAction("CreateUniversity", "SuperAdmin");
        }

        public ActionResult ManageUniversities()
        {
            var unis = SuperAdminService.GetUniversities();
            return View(unis.Result);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveUniversity(int UniversityId)
        {
            if (UniversityId != 0)
            {
                await SuperAdminService.RemoveUniversity(UniversityId).ConfigureAwait(true); ;
                _log.LogInformation("University was removed");
                return RedirectToAction("ManageUniversities", "SuperAdmin");
            }
            return RedirectToAction("ManageUniversities", "SuperAdmin");
        }
    }
}
