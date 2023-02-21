using System;
using Microsoft.EntityFrameworkCore;
using WiredBrainCoffee.EmployeeManager.Data.Models;

namespace WiredBrainCoffee.EmployeeManager.Data
{
	public class EmployeeManagerDbContext:DbContext
	{
		public EmployeeManagerDbContext(DbContextOptions<EmployeeManagerDbContext> options):base(options){}
		public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<Department> Departments => Set<Department>();

    }
}

