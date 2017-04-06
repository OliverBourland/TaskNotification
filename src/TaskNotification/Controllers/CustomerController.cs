using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskNotification.Repositories;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskNotification.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerRepository customerRepo;

        public CustomerController(ICustomerRepository repo)
        {
            customerRepo = repo;
        }

        [Authorize(Roles = "Administrator")]
        public ViewResult Index()
        {

            return View(customerRepo.GetAllCustomers());
        }
    }
}
