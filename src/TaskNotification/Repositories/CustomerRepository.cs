using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskNotification.Models;

namespace TaskNotification.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private ApplicationDbContext context;

        public IEnumerable<Customer> Customer
        {
            get
            {
                return context.Customers.ToList();
            }
        }

        public CustomerRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public List<Customer> GetAllCustomers()
        {
            return Customer.ToList();
        }
    }
}
