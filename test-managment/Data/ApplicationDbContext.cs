using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using test_managment.Models;

namespace test_managment.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<TestHistory> TestHistories { get; set; }
        public DbSet<TestType> TestTypes { get; set; }
        public DbSet<TestAllocation> TestAllocations { get; set; }
        public DbSet<test_managment.Models.DetailsTestTypeVM> DetailsTestTypeVM { get; set; }

    }
}
