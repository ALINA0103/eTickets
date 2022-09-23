using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Country
    {
        [Key]
        public int Country_id { get; set; }
        public string? Country_Name { get; set; }
        public ICollection<State> States { get; set; }
        
    }
}
