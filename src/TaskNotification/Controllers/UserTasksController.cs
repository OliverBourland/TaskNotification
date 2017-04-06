using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskNotification.Repositories;
using TaskNotification.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskNotification.Controllers
{
    public class UserTasksController : Controller
    {
        private ITaskNotifyRepository taskRepo;
        private IUserRepository userRepo;
        private UserManager<UserIdentity> userManager;

        public UserTasksController(UserManager<UserIdentity> userMgr, ITaskNotifyRepository repo, IUserRepository user)
        {
            taskRepo = repo;
            userRepo = user;
            userManager = userMgr;
        }

        
        [Authorize]
        public async Task<IActionResult> Index() //User user
        {
            UserIdentity userId = new UserIdentity();
            string name = HttpContext.User.Identity.Name;
            userId = await userManager.FindByNameAsync(name);
            User user = userRepo.GetUser(userId.UserName);

            return View(taskRepo.GetAllTasksForMember(user));
        }

        public IActionResult Completed(int tasknotifyId)
        {
            TaskNotify task = taskRepo.GetTask(tasknotifyId);
            task.TaskCompleted = true;
            task.CompletionDate = DateTime.Now;
            taskRepo.Update(task);
            return RedirectToAction("Index");
        }
    }
}
