using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class CreateRoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
