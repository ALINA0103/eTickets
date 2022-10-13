namespace eTickets.Data.ViewModel
{
    public class ShoppingViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
