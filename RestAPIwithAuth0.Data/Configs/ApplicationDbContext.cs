using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RestAPIwithAuth0.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestAPIwithAuth0.Data.Configs
{
    public class ApplicationDbContext :  DbContext // IdentityDbContext<ApplicationUser>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        // public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Audit> Audits { get; set; }
    }
}


