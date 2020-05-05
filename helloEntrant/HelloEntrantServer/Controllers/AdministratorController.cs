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
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace HelloEntrantServer.Controllers
{
    //[Authorize(Roles = "Administrator")]
    public class AdministratorController : Controller
    {
        public IAdministratorService AdministratorService { get; }

        readonly ILogger<AdministratorController> _log;

        private IHubContext<InfoHub> HubContext { get; set; }


        public AdministratorController(IAdministratorService AdministratorService, ILogger<AdministratorController> log, IHubContext<InfoHub> hubContext)
        {
            this.AdministratorService = AdministratorService;
            this._log = log;
            this.HubContext = hubContext;
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

            await this.HubContext.Clients.All.SendAsync("CreateSpeciality", 
                speciality.FucaltyName,
                speciality.SpecialityName, 
                speciality.BudgetPlaceNumber, 
                speciality.PaidPlaceNumber,
                speciality.TestNeeded1,
                speciality.TestNeeded2,
                speciality.TestNeeded3
               );
            return View();
        }

        public async Task<ActionResult> GetUniversity(int id)
        {
            var universityAndFaculties = await this.AdministratorService.GetUniversityAsync(id).ConfigureAwait(true);
            if (universityAndFaculties == null) return RedirectToAction();

            ViewBag.iseditable = false;

            if (User.Identity.IsAuthenticated)
            {
                var userId = User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier).Value;

                //ViewBag.iseditable = userId == universityAndFaculties.CurrentUniversity.UserId;
            }

            _log.LogInformation("Show university");
            return View("University", universityAndFaculties);
        }
        public async Task<ActionResult> GetFaculty(int id, string message = null)
        {
            var facultyAndSpecialities = await this.AdministratorService.GetFacultyAsync(id).ConfigureAwait(true); ;
            if (facultyAndSpecialities == null) return RedirectToAction();

            ViewBag.iseditable = false;

            if (User.Identity.IsAuthenticated)
            {
                var userId = User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier).Value;
                                
            }

            return View("Faculty", facultyAndSpecialities);
        }

        public async Task<ActionResult> GetRating (int specialityId)
        {
            var ratings = await this.AdministratorService.GetRatingAsync(specialityId);

            return View(ratings);
        }
    }
}
