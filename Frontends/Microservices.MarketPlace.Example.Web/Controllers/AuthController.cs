using Microservices.MarketPlace.Example.Web.Models;
using Microservices.MarketPlace.Example.Web.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservices.MarketPlace.Example.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IResourceOwnerPasswordTokenService _resourceOwnerPasswordTokenService;

        public AuthController(IResourceOwnerPasswordTokenService resourceOwnerPasswordTokenService)
        {
            _resourceOwnerPasswordTokenService = resourceOwnerPasswordTokenService;
        }

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SigninInput signinInput)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var response = await _resourceOwnerPasswordTokenService.SignIn(signinInput);

            if (!response.IsSuccessful)
            {
                response.Errors.ForEach(x =>
                {
                    ModelState.AddModelError(String.Empty, x);
                });

                return View();
            }

            return RedirectToAction(nameof(Index), "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            await _resourceOwnerPasswordTokenService.RevokeRefreshToken();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}
