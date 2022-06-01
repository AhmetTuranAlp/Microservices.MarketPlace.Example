﻿using Microservices.MarketPlace.Example.Web.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Microservices.MarketPlace.Example.Web.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _userService.GetUser());
        }
    }
}
