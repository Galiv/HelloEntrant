using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.User;
using Application.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HelloEntrantServer.Controllers
{
    public class UserController : Controller
    {


        public IUserService userService { get; }
        public ITestService testService { get; }


        public UserController (IUserService userService, ITestService testService)
        {
            this.userService = userService;
            this.testService = testService;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> PersonalCabinet()
        {
            var profile = await userService.GetUserInfo(User.Identity.Name).ConfigureAwait(true);
            return View(profile);
            
            //return View(new UserProfile());
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePersonalInfo(UserProfile request)
        {
            await userService.UpdateUserInfo(request);

            return RedirectToAction("PersonalCabinet", "User");
        }

        [HttpPost]
        public async Task<IActionResult> AddTests(UserProfile request)
        {
            await testService.SaveTests(request, User.Identity.Name);

            return RedirectToAction("PersonalCabinet", "User");
        }

        public async Task<IActionResult> ApplyButtonExecute(int specialityId, int facultyId)
        {
            if (specialityId != 0)
            {
                await userService.ApplyButtonExecuteAsync(specialityId).ConfigureAwait(true);
            }

            return RedirectToAction("GetFaculty", "Administrator", new { id = facultyId });
        }

        /*[HttpPost]
        public async Task<IActionResult> AddFile(IFormFileCollection uploads)
        {
            foreach (var uploadedFile in uploads)
            {
                // путь к папке Files
                string path = "/Files/" + uploadedFile.FileName;
                // сохраняем файл в папку Files в каталоге wwwroot
                /*using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }
                FileModel file = new FileModel { Name = uploadedFile.FileName, Path = path };
                _context.Files.Add(file);
            }
           // _context.SaveChanges();

            return RedirectToAction("Index");
        }*/
    }
}
