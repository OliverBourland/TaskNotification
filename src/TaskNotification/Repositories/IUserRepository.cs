using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskNotification.Models;

namespace TaskNotification.Repositories
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();
        List<string> GetAllEmails();
        IEnumerable<User> Users { get; }
        User GetUser(int id);
        User GetUser(string username);
        int Create(User user);
    }
}
