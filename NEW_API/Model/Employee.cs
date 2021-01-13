using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_Host.Model
{
    public class Employee:DbContext

    {
        public Employee(DbContextOptions<Employee> options) : base(options)
        {
                
        }
        public DbSet<Demo> Demos { get; set; }

    }
}
