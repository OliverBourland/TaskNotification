using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskNotification.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public string Title { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CreationDate { get; set; }
        public Customer Customer { get; set; }
    }
}
