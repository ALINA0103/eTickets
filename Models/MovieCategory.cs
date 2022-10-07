using System;
using System.Collections.Generic;

namespace eTickets.Models
{
    public partial class MovieCategory
    {
        
        public int Id { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
