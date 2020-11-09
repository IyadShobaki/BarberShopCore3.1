using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BarberShop_Models.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        [Required]
        public DateTime AppointmentDate { get; set; }

        //[ForeignKey("ApplicationUser")]
        //public string User_Id { get; set; }
        //[Required]
        //public ApplicationUser ApplicationUser { get; set; }
        [ForeignKey("Customer")]
        public int Customer_Id { get; set; }
        [Required]
        public Customer Customer { get; set; }
        [ForeignKey("SalonService")]
        public int SalonService_Id { get; set; }
        [Required]
        public SalonService SalonService { get; set; }
    }
}
