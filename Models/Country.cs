using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTickets.Models
{
    public class Country
    {
        [Key]
        public int Country_id { get; set; }
        public string? Country_Name { get; set; }
        [ForeignKey("Country_id")]
        public ICollection<State> States { get; set; }
        
    }
}
