using System.ComponentModel.DataAnnotations;

namespace RejestracjaSal.Models
{
    public class Reservations_Rooms
    {
        [Key]
        public int ReservationRoom_Id { get; set; }
        public int Reservation_id { get; set; }
        public DateTime Reservation_start_date { get; set; }
        public DateTime Reservation_end_date { get; set; }
        public float Reservation_price { get; set; }
        public int Room_id { get; set; }
    }
}
