using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Application.DTOs;
using Application.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HelloEntrantServer.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdministratorController : Controller
    {
        public IAdministratorService AdministratorService { get; }

        public AdministratorController(IAdministratorService AdministratorService)
        {
            this.AdministratorService = AdministratorService;
        }       

        public IActionResult CreateFaculty()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateFaculty(CreateFaculty faculty)
        {
            faculty.UserId = User.Claims.Where(claim => claim.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;

            await AdministratorService.CreateFaculty(faculty);

            return View();
        }

    }
}