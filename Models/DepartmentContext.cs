using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace WebApiDepart.Models
{
    public class DepartmentContext: DbContext
    {
        public DepartmentContext(DbContextOptions<DepartmentContext> options) : base(options)
        {
           
        }
        public DbSet<Department> Departments { get; set; }

    }
}
