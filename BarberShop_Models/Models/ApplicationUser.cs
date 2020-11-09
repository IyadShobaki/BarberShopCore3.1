﻿using Microsoft.AspNetCore.Identity;  // Microsoft.AspNetCore.Identity.EntityFrameworkCore   NuGet Package
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace BarberShop_Models.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
    }
}
