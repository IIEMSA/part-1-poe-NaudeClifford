using System.ComponentModel.DataAnnotations;
using System.Security;

namespace CLDV6211POEProject.Models
{
    public class Venue1
    {
        [Key]
        public required int Venue_Id { get; set; }
        public required string Venue_Name { get; set; }

        public required string Location1 { get; set; }
        public required int Capacity { get; set; }

        public string? ImageURL { get; set; }

        public List<Bookings1> Bookings1 { get; set; } = new();
    }
}
