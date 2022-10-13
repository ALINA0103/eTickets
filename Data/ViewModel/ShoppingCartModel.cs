namespace eTickets.Data.ViewModel
{
    public class ShoppingCartModel
    {
        internal double? Total;

        public int Id { get; set; }
        public int Quantity { get; set; }
        
        public double? Price { get; set; }
        public string? ImageUrl { get; set; }
        
    }
}
