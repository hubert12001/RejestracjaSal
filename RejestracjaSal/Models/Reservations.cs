using System.ComponentModel.DataAnnotations;

namespace RejestracjaSal.Models
{
    public class Reservations
    {
        [Key]
        public int Reservation_id { get; set; }
        public int User_id {  get; set; }
        public int Total_price { get; set; }
        public bool Paid {  get; set; }
        public string? Comments {  get; set; }
    }
}
