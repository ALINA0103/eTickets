using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class UserLogins
    {
        [Key]
        public int UserId { get; set; }
        public string User_Name { get; set; }
        public string password { get; set; }
    }
}
