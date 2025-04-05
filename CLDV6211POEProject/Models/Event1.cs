using System.ComponentModel.DataAnnotations;
using System.Security;

namespace CLDV6211POEProject.Models
{
    public class Event1
    {
        [Key]
        public required int Event_Id { get; set; }
        public required string Event_Name { get; set; }

        public required DateOnly Event_Date { get; set; }
        public required string Description1 { get; set; }

        public required int Venue_Id { get; set; }

        public List<Bookings1> Bookings1 { get; set; } = new();

    }
}
