using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskNotification.Models;

namespace TaskNotification.Repositories
{
    public interface IOrderRepository
    {
        Order GetOrder(int id);
        List<Order> GetAllCustomerOrders(Customer customer);
        List<Order> GetAllOrders();
        IEnumerable<Order> Orders { get; }
        bool DoesOrderExist(int id);
        
    }
}
