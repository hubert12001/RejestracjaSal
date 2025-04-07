using System.ComponentModel.DataAnnotations;

namespace RejestracjaSal.Models
{
    public class Roles
    {
        [Key]
        public int Roles_id { get; set; }
        public string Name { get; set;}
    }
}
