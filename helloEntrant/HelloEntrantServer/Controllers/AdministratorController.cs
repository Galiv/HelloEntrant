using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Application.DTOs;
using Application.DTOs.Administrator;
using Application.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HelloEntrantServer.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdministratorController : Controller
    {
        public IAdministratorService AdministratorService { get; }

        readonly ILogger<AdministratorController> _log;


        public AdministratorController(IAdministratorService AdministratorService, ILogger<AdministratorController> log)
        {
            this.AdministratorService = AdministratorService;
            this._log = log;
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

            _log.LogInformation("Created Faculty");
            return View();
        }
        public async Task<IActionResult> CreateSpeciality()
        {            
            ViewBag.Faculties = await this.AdministratorService.GetFaculties(
                await this.AdministratorService.GetUniversityId(User.Identity.Name));
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSpeciality(CreateSpeciality speciality)
        { 

            await AdministratorService.CreateSpeciality(speciality);

            ViewBag.Faculties = await this.AdministratorService.GetFaculties(
                await this.AdministratorService.GetUniversityId(User.Identity.Name));
            _log.LogInformation("Created Speciality");
            return View();
        }


    }
}