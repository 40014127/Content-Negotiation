using Content.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Content
{
    public class UserContext:DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
       : base(options)
        { 
        
        }

        public DbSet<Employee> employees { get; set; }
        //public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        //{
        //    LoadDefaultUsers();
        //}

       

       
    }
}
