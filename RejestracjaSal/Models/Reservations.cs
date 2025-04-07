using System.ComponentModel.DataAnnotations;

namespace RejestracjaSal.Models
{
    public class Reservations
    {
        [Key]
        public int Reservation_id { get; set; }
        public int User_id {  get; set; }
        public int Room_id {  get; set; }
        public int Reservation_price { get; set; }
        public DateTime Reservation_start_date { get; set; }
        public DateTime Reservation_end_date { get; set; }
        public string? Comments {  get; set; }
    }
}
