using eTickets.Data.ViewModel;

namespace eTickets.Models
{
    public class ViewCartVC
    {
        public List<Moviesvm> Movies { get; set; } = new List<Moviesvm>();    
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
