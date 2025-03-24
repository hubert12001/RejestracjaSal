using System.ComponentModel.DataAnnotations;

namespace RejestracjaSal.Models
{
    public class RoomTypes
    {
        [Key]   
        public int Type_id {  get; set; }
        public string Name {  get; set; }
    }
}
