using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security;
using Microsoft.EntityFrameworkCore;

namespace CLDV6211POEProject.Models
{
    public class Bookings1
    {
        [Key]
        public required int Booking_Id { get; set; }

        public required int Event_Id { get; set; }
       
        public required int Venue_Id { get; set; }

        public required DateOnly Booking_Date { get; set; }

        public List<Event1> Event1 { get; set; } = new();

        public List<Venue1> Venue1 { get; set; } = new();


    }
}
