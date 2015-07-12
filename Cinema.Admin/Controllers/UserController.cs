using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cinema.Domain.Interfaces;
using Cinema.Infrastrucutre;
using Cinema.Infrastrucutre.Repositories;

namespace Cinema.Admin.Controllers
{
    public class UserController : Controller
    {
        private IUserRepository _userRepository;

        public UserController()
        {
            string cnn = ConfigurationManager.ConnectionStrings["CinemaCnn"].ToString();
            var dbContext = new DatabaseContext(cnn);
            var userRepository = new UserRepository(dbContext);
            _userRepository = userRepository;
        }

        // GET: User
        public ActionResult Index()
        {
            var result = _userRepository.GetAll();
            return View(result);
        }

        public ActionResult Delete(int id)
        {
            _userRepository.Delete(id);
            _userRepository.Save();
            return RedirectToAction("Index");
        }

    }
}