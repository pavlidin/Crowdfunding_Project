﻿using CrowdFundingCH.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CrowdFundingCH.Areas.Identity.Data
{
    public class CrowdFundingDBContext : IdentityDbContext<AllUsers>
    {
        public CrowdFundingDBContext(DbContextOptions<CrowdFundingDBContext> options)
            : base(options)
        {

        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Fund> Funds { get; set; }

        public DbSet<Multimedia> Multimedia { get; set; }
        public DbSet<BackedProject> BackedProjects { get; set; }
        //public DbSet<ProjectCategory> ProjectCategory { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

        }
    }
}