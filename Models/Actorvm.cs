namespace eTickets.Models

{
    public class Actorvm
    {
        
        public IFormFile ProfilePictureUrl { get; set; } = null!;
        public string? FullName { get; set; }
        public string? Bio { get; set; }
    }
}
