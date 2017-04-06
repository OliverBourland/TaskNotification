using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskNotification.Models;

namespace TaskNotification.Repositories
{
    public interface ITaskNotifyRepository
    {
        List<TaskNotify> GetAllTask();
        List<TaskNotify> GetAllTasksForMember(User name);
        List<TaskNotify> GetAllTasksForMember(int Id);
        List<TaskNotify> GetAllTasksForOrder(Order order);
        List<TaskNotify> GetAllTasksForOrder(int orderId);
        TaskNotify GetTask(int Id);
        IEnumerable<TaskNotify> Tasks { get; }
        int Create(TaskNotify task);
        int Update(TaskNotify task);
        List<TaskNotify> GetAllTasksFromMember(User name);
    }
}
