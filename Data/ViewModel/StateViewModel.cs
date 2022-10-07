using eTickets.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eTickets.Data.ViewModel
{
    public class StateViewModel
    {
        public int Id { get; set; }
        public string StateName { get; set; }
        public int Country_id { get; set; }
        public virtual Country Country { get; set; }
        public List<SelectListItem> States { get; set; }
    }
}
