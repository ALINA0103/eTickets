using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class State
    {
        [Key]
        
            public int Id { get; set; }
            public string StateName { get; set; }
            public int CountryId { get; set; }
            public virtual Country Country { get; set; }
        
    }
}
