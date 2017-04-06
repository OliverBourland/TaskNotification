using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskNotification.Repositories;
using TaskNotification.Models;
using Microsoft.AspNetCore.Identity;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskNotification.Controllers
{
    public class TaskController : Controller
    {
        private ITaskNotifyRepository taskRepo;
        private IUserRepository userRepo;
        private UserManager<UserIdentity> userManager;

        public TaskController(UserManager<UserIdentity> userMgr, ITaskNotifyRepository repo, IUserRepository user)
        {
            taskRepo = repo;
            userRepo = user;
            userManager = userMgr;
        }

        public ViewResult Index()
        {
            return View(taskRepo.Tasks);
        }

        
        public IActionResult Completed(int tasknotifyId)
        {
            TaskNotify task = taskRepo.GetTask(tasknotifyId);
            task.TaskCompleted = true;
            task.CompletionDate = DateTime.Now;
            taskRepo.Update(task);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> TasksPostedByMember()
        {
            UserIdentity userId = new UserIdentity();
            string name = HttpContext.User.Identity.Name;
            userId = await userManager.FindByNameAsync(name);
            User user = userRepo.GetUser(userId.UserName);
            return View(taskRepo.GetAllTasksFromMember(user));
        }
    }
}
