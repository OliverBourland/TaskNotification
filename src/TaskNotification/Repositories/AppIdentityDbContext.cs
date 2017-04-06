using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskNotification.Models;

namespace TaskNotification.Repositories
{
    public class AppIdentityDbContext : IdentityDbContext<UserIdentity>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options)
           : base(options) { }
    }
}
