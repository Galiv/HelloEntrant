using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.SuperAdmin;
using Application.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HelloEntrantServer.Controllers
{
    public class SuperAdminController:Controller
    {
        ISuperAdminService SuperAdminService;
        public SuperAdminController(ISuperAdminService SuperAdminService)
        {
            this.SuperAdminService = SuperAdminService;
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
                return RedirectToAction("ManageUniversities", "SuperAdmin");
            }

            return RedirectToAction("CreateUniversity", "SuperAdmin");
        }

        public ActionResult ManageUniversities()
        {
            var unis = SuperAdminService.GetUniversities();
            return View(unis.Result);
        }
    }
}
