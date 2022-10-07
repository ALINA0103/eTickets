using eTickets.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eTickets.ViewModel
{
    public class CountriesViewModel
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        
        public List<SelectListItem> countries { get; set; }
        public List<SelectListItem> States { get; set; }
        public int Id { get; set; }

    }
}
