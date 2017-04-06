using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskNotification.Repositories;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskNotification.Controllers
{
    public class UserListController : Controller
    {
        private IUserRepository userRepo;

        public UserListController(IUserRepository repo)
        {
            userRepo = repo;
        }

        public ViewResult Index(string user)
        {

            return View(userRepo.GetAllUsers());
        }
    }
}
