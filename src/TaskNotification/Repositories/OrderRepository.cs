using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskNotification.Models;

namespace TaskNotification.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private ApplicationDbContext context;

        public IEnumerable<Order> Orders
        {
            get
            {
                return context.Orders.Include(o => o.Customer).ToList();
            }
        }

        public OrderRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public Order GetOrder(int id)
        {
            return Orders.FirstOrDefault(u => u.OrderID == id);
        }

        public List<Order> GetAllCustomerOrders(Customer customer)
        {
            return Orders.Where(o => o.Customer == customer).ToList();
        }
        public List<Order> GetAllOrders()
        {
            return context.Orders.ToList();
        }

        public bool DoesOrderExist(int id)
        {
            Order order = GetOrder(id);
            if (order == null)
                return false;
            else
                return true;
        }
    }
}
