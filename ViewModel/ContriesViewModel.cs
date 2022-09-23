using eTickets.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eTickets.ViewModel
{
    public class ContriesViewModel
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public List<SelectListItem> cotries { get; set; }
    }
}
