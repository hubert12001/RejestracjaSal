using System.ComponentModel.DataAnnotations;

namespace RejestracjaSal.Models
{
    public class Reservations_Rooms
    {
        [Key]
        public int Reservation_id { get; set; }
        public int Room_id { get; set; }
    }
}
