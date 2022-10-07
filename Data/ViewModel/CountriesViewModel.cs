using Microsoft.AspNetCore.Mvc.Rendering;

namespace eTickets.Data.ViewModel
{
    public class CountriesViewModel
    {
        public int Country_id { get; set; }
        public string Country_Name { get; set; }
        public int Id { get; set; }
        public string StateName { get; set; }

        public List<SelectListItem> countries { get; set; }
        public List<SelectListItem> States { get; set; }
    }
}
