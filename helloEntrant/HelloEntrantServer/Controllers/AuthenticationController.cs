using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.IServices;
using Microsoft.AspNetCore.Mvc;

namespace HelloEntrantServer.Controllers
{
    public class AuthenticationController : Controller
    {
        //returns the page where the user need to enter his email and password

        IAuthService _authService;

        public AuthenticationController(IAuthService authservice)
        {
            _authService = authservice;
        }

        [HttpGet]
        public IActionResult SignIn()
        {

            return View();
        }



        //accepts Sign in data
        [HttpPost]
        public async Task<IActionResult> SignIn(SignInRequest request)
        {
            if (ModelState.IsValid)
            {
                var result = await _authService.SignIn(request);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Login or password is incorrect!!");
                }
            }

            return View();
        }

        //returns the page where the user need to enter his email and password
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        //accepts Sign in data
        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            if (ModelState.IsValid)
            {
                if (await _authService.FindByNameAsync(request.email) == null)
                {
                    if ((await _authService.Register(request)).Succeeded)
                    {
                        return RedirectToAction("Index", "User");
                    }
                }
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> SignOut()
        {
            await _authService.SignOut();

            return RedirectToAction("SignIn", "Authentication");
        }
    }
}