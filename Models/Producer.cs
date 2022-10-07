using System;
using System.Collections.Generic;

namespace eTickets.Models
{
    public partial class Producer
    {
        

        public int Id { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public string? FullName { get; set; }
        public string? Bio { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
