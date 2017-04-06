using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskNotification.Models;

namespace TaskNotification.Repositories
{
    public class UserRepository : IUserRepository
    {
        private ApplicationDbContext context;

        public IEnumerable<User> Users
        {
            get
            {
                return context.Users.ToList();
            }
        }

        public UserRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
       
        public List<string> GetAllEmails()
        {
            throw new NotImplementedException();
        }

        public List<User> GetAllUsers()
        {
            return context.Users.ToList();
        }

        public int Create(User user)
        {
            context.Users.Add(user);
            return context.SaveChanges();
        }

        public User GetUser(int id)
        {
            return Users.First(u => u.UserID == id);
        }

        public User GetUser(string username)
        {
            return Users.First(u => u.Email == username);
        }

       
    }
}
