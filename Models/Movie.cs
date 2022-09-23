using System;
using System.Collections.Generic;

namespace eTickets.Models
{
    public partial class Movie
    {
        public Movie()
        {
            Actors = new HashSet<Actor>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? MovieCategoryId { get; set; }
        public int CinemaId { get; set; }
        public int ProducerId { get; set; }

        public virtual Cinema Cinema { get; set; } = null!;
        public virtual MovieCategory? MovieCategory { get; set; }
        public virtual Producer Producer { get; set; } = null!;

        public virtual ICollection<Actor> Actors { get; set; }
    }
}
