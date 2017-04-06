using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskNotification.Models;

namespace TaskNotification.Repositories
{
    public class TaskNotifyRepository : ITaskNotifyRepository
    {
        private ApplicationDbContext context;

        public TaskNotifyRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<TaskNotify> Tasks
        {
            get
            {
                return context.TaskNotifies.Include(m => m.TaskFor).Include(m => m.PostedBy).Include(m => m.Order).ToList();
            }
        }

        public List<TaskNotify> GetAllTask()
        {
            return (from t in context.TaskNotifies
                    
                    select t).Include(m => m.TaskFor).ToList();
        }

        public List<TaskNotify> GetAllTasksForMember(int Id)
        {
            return (from t in context.TaskNotifies
                    where t.TaskFor.UserID == Id
                    select t).Include(m => m.TaskFor).ToList();
        }

        public List<TaskNotify> GetAllTasksForMember(User name)
        {
            return (from t in context.TaskNotifies
                    where t.TaskFor == name
                    select t).ToList();
        }

        public List<TaskNotify> GetAllTasksFromMember(User name)
        {
            return Tasks.Where(t => t.PostedBy == name).ToList();
        }

        public List<TaskNotify> GetAllTasksForOrder(Order order)
        {
            return (from i in context.TaskNotifies
                    where i.Order == order
                    select i).ToList();
        }

        public List<TaskNotify> GetAllTasksForOrder(int orderId)
        {
            return Tasks.Where(t => t.Order.OrderID == orderId).ToList();
        }

        public TaskNotify GetTask(int Id)
        {
            return Tasks.First(t => t.TaskNotifyID == Id);
           // return (from t in context.TaskNotifies
                   // where t.TaskNotifyID == Id
                   // select t);
        }

        public int Create(TaskNotify task)
        {
            context.TaskNotifies.Add(task);
            return context.SaveChanges();
        }

        public int Update(TaskNotify task)
        {           
                context.TaskNotifies.Update(task);
            return context.SaveChanges();        
        }

    }
}
