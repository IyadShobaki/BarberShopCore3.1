using System;
using System.Collections.Generic;
using System.Text;
using BarberShop_Models.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BarberShop_DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<SalonService> SalonServices { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

    }
}
