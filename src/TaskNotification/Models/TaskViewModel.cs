using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskNotification.Models
{
    public class TaskViewModel
    {
        public int TaskNotifyID { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }            
        public DateTime DueDate { get; set; }
        public TaskNotify Task { get; set; }
        public User TaskFor { get; set; }
        public int UserId { get; set; }
        public int OrderId { get; set; }
    }
}
