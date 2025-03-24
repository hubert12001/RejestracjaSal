using System.ComponentModel.DataAnnotations;

namespace RejestracjaSal.Models
{
    public class Locations
    {
        [Key]
        public int Location_id { get; set; } 
        public string Name { get; set; } 
        public string Bulding_code { get; set; }
        public string City { get; set; }
        public string Street {  get; set; }
        public string Zip_code { get; set; }
        public string? Description {  get; set; }
    }
}
