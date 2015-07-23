using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Cinema.Domain.Entities;
using Cinema.Domain.Interfaces;
using Cinema.Infrastrucutre;
using Cinema.Infrastrucutre.Repositories;
using Cinema.Services.Services;
using Cinema.SharedModels.DTOs;

namespace Cinema.Website.Controllers
{
    public class AccountController : Controller
    {
        private IUserRepository _userRepository;
        private UserService _userService;

        public AccountController()
        {
            string cnn = ConfigurationManager.ConnectionStrings["CinemaCnn"].ToString();
            var dbContext = new DatabaseContext(cnn);
            var userRepo = new UserRepository(dbContext);
            
            _userRepository = userRepo;
            _userService = new UserService(userRepo);
        }

        // GET: Account
        public ActionResult Registar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registar(UserDto dto)
        {
            if (ModelState.IsValid)
            {
                _userService.AddUser(dto);
                return RedirectToAction("Index", "Home");
            }
            return View(dto);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserDto dto)
        {
            var result = _userService.Login(dto.Username, dto.Password);
            if (result)
            {
                Session["User"] = new User()
                {
                    Username = dto.Username,
                    Id = dto.Id
                };
                return RedirectToAction("Index", "Home");
            }
            return View(dto);
        }

        public ActionResult LogOff()
        {
            Session.Clear();
            return RedirectToAction("Index","Home");
        }
    }
}