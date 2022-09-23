using eTickets.Data.Enums;

namespace eTickets.Models
{
    public class Moviesvm
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }
        public IFormFile ImageURL { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public MovieCategory? MovieCategory { get; set; }
    }
}
