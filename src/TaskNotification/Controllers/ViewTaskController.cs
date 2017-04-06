using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskNotification.Repositories;
using TaskNotification.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskNotification.Controllers
{
    public class ViewTaskController : Controller
    {
        private ITaskNotifyRepository taskRepo;

        public ViewTaskController(ITaskNotifyRepository repo)
        {
            taskRepo = repo;
        }

        public IActionResult Index(int tasknotifyId)
        {
            TaskNotify task = taskRepo.GetTask(tasknotifyId);
            if (!task.TaskViewed)
                task.TaskViewed = true;
            taskRepo.Update(task);
            return RedirectToAction("Index", "UserTasks");
        }
    }
}
