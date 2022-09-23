﻿using System;
using System.Collections.Generic;

namespace eTickets.Models
{
    public partial class Cinema
    {
        public Cinema()
        {
            Movies = new HashSet<Movie>();
        }

        public int Id { get; set; }
        public string? Logo { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
