using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public partial class Cinema
    {

        [Key]
        public int Id { get; set; }
        public string? Logo { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        //public virtual ICollection<Movie> Movies { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
