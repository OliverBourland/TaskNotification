using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskNotification.Models
{
    public class TaskNotify
    {
        public int TaskNotifyID { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "You must enter at least 2 characters")]
        [Display(Name = "Task Title")]
        public string Title { get; set; }
        [Required]
        [StringLength(600, MinimumLength = 3, ErrorMessage = "Task body exceeds max length or too short")]
        [Display(Name = "Body")]
        public string Body { get; set; }
        public User TaskFor { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CompletionDate { get; set; }
        public List<User> ViewedBy { get; set; }
        public User CompletedBy { get; set; }
        public User PostedBy { get; set; }
        public bool TaskViewed { get; set; }
        public bool TaskCompleted { get; set; }
        public Order Order { get; set; }

    }
}
