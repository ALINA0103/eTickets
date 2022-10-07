using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public partial class Actor
    {
        public Actor()
        {
            Movies = new HashSet<Movie>();
        }

        public int Id { get; set; }
        public string ProfilePictureUrl { get; set; } = null!;
        public string? FullName { get; set; }
        public string? Bio { get; set; }
        public List<Actor_Movie> Actors_Movies { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
        
    }
}
