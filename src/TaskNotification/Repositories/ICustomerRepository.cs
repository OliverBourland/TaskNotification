using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskNotification.Models;

namespace TaskNotification.Repositories
{
    public interface ICustomerRepository
    {
        List<Customer> GetAllCustomers();
    }
}
