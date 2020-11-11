using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BarberShop_Models.DTOs
{
    public class AppointmentDTO
    {
        public int Id { get; set; }
        [Required]
        public DateTime AppointmentDate { get; set; }
        public int Customer_Id { get; set; }
        public int SalonService_Id { get; set; }
    }
}
