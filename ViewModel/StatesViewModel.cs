using Microsoft.AspNetCore.Mvc.Rendering;

namespace eTickets.ViewModel
{
    public class StatesViewModel
    {
        public int Id { get; set; }
        public string StateName { get; set; }
        public int Country_id { get; set; }
        public List<SelectListItem> states { get; set; }
    }
}
