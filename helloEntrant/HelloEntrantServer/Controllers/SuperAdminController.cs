using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public ActionResult Universities()
        {
            var unis = SuperAdminService.GetUniversities();
            return View(unis);
        }

        [HttpGet]
        [Authorize(Roles = "SuperAdmin")]
        public ActionResult CreateUniversity()
        {
            return View();
        }

    }
}
