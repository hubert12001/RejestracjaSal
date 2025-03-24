using System.ComponentModel.DataAnnotations;

namespace RejestracjaSal.Models
{
    public class Rooms
    {
        [Key]
        public int Room_id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Location_id { get; set; }
        public int Type_id { get; set; }
        public float Room_price { get; set; }
        public string? Description { get; set; }
        public string Image { get; set; }
    }
}
