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
    public class TaskFormController : Controller
    {
        private ITaskNotifyRepository taskRepo;
        private IUserRepository userRepo;
        private UserManager<UserIdentity> userManager;
        private IOrderRepository orderRepo;

        public TaskFormController(IOrderRepository ordRp, UserManager<UserIdentity> userMgr, ITaskNotifyRepository repo, IUserRepository user)
        {
            taskRepo = repo;
            userRepo = user;
            userManager = userMgr;
            orderRepo = ordRp;
        }

        [HttpGet]
        public ViewResult TaskForm(int userId)
        {
            var t = new TaskViewModel();
            t.UserId = userId;
            t.Task = new TaskNotify();

            return View(t);
        }


        [HttpPost]
        public async Task<IActionResult> TaskForm(TaskViewModel taskVm)
        {
            if (orderRepo.DoesOrderExist(taskVm.OrderId))
            {
                if (ModelState.IsValid)
                {
                    UserIdentity userId = new UserIdentity();
                    User user = userRepo.GetUser(taskVm.UserId);
                    Order order = orderRepo.GetOrder(taskVm.OrderId);
                    TaskNotify task = new TaskNotify
                    {
                        DueDate = taskVm.DueDate,
                        Body = taskVm.Body,
                        CreationDate = DateTime.Now,
                        Title = taskVm.Title,
                        TaskFor = user,
                        Order = order
                    };
                    string name = HttpContext.User.Identity.Name;
                    userId = await userManager.FindByNameAsync(name);
                    task.PostedBy = userRepo.GetUser(userId.UserName);
                    taskRepo.Create(task);
                    return RedirectToAction("Index", "Task");
                }
                else
                {
                    return View(taskVm);
                }

            }
            else
            {
                ModelState.AddModelError(nameof(taskVm.OrderId), "OrderId Does Not Exist");

                return View(taskVm);
            }
            
           

        }
    }
}
