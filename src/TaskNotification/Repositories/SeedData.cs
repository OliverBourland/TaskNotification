using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskNotification.Models;

namespace TaskNotification.Repositories
{
    public static class SeedData
    {
        public static async Task EnsurePopulated(IApplicationBuilder app)
        {
            UserManager<UserIdentity> userManager = app.ApplicationServices.GetRequiredService<UserManager<UserIdentity>>();
            RoleManager<IdentityRole> roleManager = app.ApplicationServices.GetRequiredService<RoleManager<IdentityRole>>();

            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            if (!context.TaskNotifies.Any())
            {
                
                Customer customer = new Models.Customer { Company = "9Wood", ContactName = "Woody Wonkers", PhoneNumber = "541-999-2222", Address = "177 West 128th Ave, Boring, Oregon 98115", Email = "woody@9wood.com" };
                context.Customers.Add(customer);
                Order order = new Order { Customer = customer, CreationDate = DateTime.Now, DueDate = DateTime.Parse("5/15/17"), Title = "Business Cards" };
                context.Orders.Add(order);
                customer = new Customer { Company = "Smith Family", ContactName = "Sam Mckracken", PhoneNumber = "541-999-2852", Address = "20 West 5th Ave, Eugene, Oregon 98115", Email = "mckrackens@smithfamily.com" };
                context.Customers.Add(customer);
                order = new Order { Customer = customer, CreationDate = DateTime.Now, DueDate = DateTime.Parse("5/20/17"), Title = "Bookmarks" };
                context.Orders.Add(order);

                User user = new User { Name = "Chris Lemon", FirstName = "Chris", LastName = "Lemon", Password = "Chrislemon1!", Email = "chrislemon@gmail.com" };
                context.Users.Add(user);
                User user2 = new User { Name = "John Hamm", FirstName = "John", LastName = "Hamm", Password = "Johnhamm1!", Email = "johnhamm@gmail.com" };
                context.Users.Add(user2);
                TaskNotify task = new TaskNotify {
                    TaskFor =user2,
                    PostedBy = user,
                    Body = "Send business card proof by the 9th",
                    CreationDate = DateTime.Now,
                    DueDate = DateTime.Parse("5/9/17"),
                    Order = order,
                    Title = "9Wood Proof",
                    TaskViewed = false,
                    TaskCompleted = false
                };
                context.TaskNotifies.Add(task);

                customer = new Models.Customer { Company = "Willamette Family", ContactName = "Kathy Kay", PhoneNumber = "541-111-2222", Address = "744 River Ave, Eugene, Oregon 97401", Email = "kath@willfam" };
                context.Customers.Add(customer);
                order = new Order { Customer = customer, CreationDate = DateTime.Now, DueDate = DateTime.Parse("5/20/17"), Title = "Presentation Folder" };
                context.Orders.Add(order);
                user = new User { Name = "Jack White", FirstName = "Jack", LastName = "White", Password = "Jackwhite1!", Email = "jackwhite@gmail.com" };
                context.Users.Add(user);
                user2 = new User { Name = "Henry Rollins", FirstName = "Henry", LastName = "Rollins", Password = "Henryrollins1!", Email = "henryrollins@gmail.com" };
                context.Users.Add(user2);
                task = new TaskNotify
                {
                    TaskFor = user2,
                    PostedBy = user,
                    Body = "Order copper die for Willamette Family Folder",
                    CreationDate = DateTime.Now,
                    DueDate = DateTime.Parse("5/6/17"),
                    Order = order,
                    Title = "Die",
                    TaskViewed = true,
                    TaskCompleted = true
                };
                context.TaskNotifies.Add(task);

                foreach (User m in context.Users)
                {
                    UserIdentity userId = new UserIdentity { UserName = m.Email };
                    
                    
                  
                        string password = m.Password;
                        string role = "User";
                        IdentityResult result = await userManager.CreateAsync(userId, password);
                        if (await roleManager.FindByNameAsync(role) == null)
                        {
                            await roleManager.CreateAsync(new IdentityRole(role));
                            if (result.Succeeded)
                            {
                                await userManager.AddToRoleAsync(userId, role);
                            }
                        }
                        
                    
                }
                User userAdmin = new User { Name = "Flim Flam", FirstName = "Flim", LastName = "Flam", Password = "Flimflam1!", Email = "flimflam@gmail.com" };
                string role2 = "Administrator";
                context.Users.Add(userAdmin);
                UserIdentity userIdAdmin = new UserIdentity { UserName = userAdmin.Email };
                string password2 = userAdmin.Password;
                IdentityResult result2 = await userManager.CreateAsync(userIdAdmin, password2);
                if (await roleManager.FindByNameAsync(role2) == null)
                {
                    await roleManager.CreateAsync(new IdentityRole(role2));
                    if (result2.Succeeded)
                    {
                        await userManager.AddToRoleAsync(userIdAdmin, role2);
                    }
                }
                context.SaveChanges();
            }
        }
    }
}
