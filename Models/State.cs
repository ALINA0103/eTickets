using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTickets.Models
{
    public class State
    {
        [Key]
        
            public int StateId { get; set; }
            public string StateName { get; set; }

            [ForeignKey("Country_id")]
            public int Country_id { get; set; }
            public virtual Country Country { get; set; }
            [ForeignKey("StateId")]
            public ICollection<City> Cities { get; set; }


    }
}
