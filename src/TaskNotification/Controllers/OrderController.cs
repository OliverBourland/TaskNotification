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
    public class OrderController : Controller
    {
        private IOrderRepository orderRepo;
        private ITaskNotifyRepository taskRepo;

        public OrderController(ITaskNotifyRepository trepo, IOrderRepository repo)
        {
            orderRepo = repo;
            taskRepo = trepo;
        }

        public ViewResult Index()
        {

            return View(orderRepo.Orders);
        }

        public ViewResult TasksForOrder(int order)
        {
            return View(taskRepo.GetAllTasksForOrder(order));
        }
    }
}
