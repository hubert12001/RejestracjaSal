using System.ComponentModel.DataAnnotations;

namespace RejestracjaSal.Models
{
    public class Users
    {
        [Key]
        public int User_id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int? Phone { get; set; }
        public int Role_id { get; set; }
        public string Login{ get; set; }
        public string Password {  get; set; }
    }
}
