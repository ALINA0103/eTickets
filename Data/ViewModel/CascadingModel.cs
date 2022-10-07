using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTickets.Data.ViewModel
{
    public class CascadingModel
    {
        public CascadingModel()
        {
            this.Countries = new List<SelectListItem>();
            this.States = new List<SelectListItem>();
            this.Cities = new List<SelectListItem>();
        }

        public List<SelectListItem> Countries { get;  set; }
        public List<SelectListItem> Cities { get; set; }
        public List<SelectListItem> States { get; }
        public string StateName { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }

        public int Country_id { get; set; }
        public int StateId { get; set; }
       
    }
}
