using eTickets.Data;
using eTickets.Data.ViewModel;
using eTickets.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;

namespace eTickets.Controllers
{
    public class HomeController : Controller
    {

        private readonly AppDbContext _context;
       

        public HomeController(AppDbContext context)
        {
            _context = context;
        }


        
        public ActionResult Index()
        {

            CascadingModel model = new CascadingModel();
            List<Country> countries = _context.Countries.ToList();
            List<SelectListItem> selectList = new List<SelectListItem>();
            foreach (var country in countries)
            {
                model.Countries.Add(new SelectListItem { Value = country.Country_id.ToString(), Text = country.Country_Name });
            }

            return View(model);
        }

       
        public JsonResult GetStateList(int Country_id)
        {
            CascadingModel model = new CascadingModel();
            
            List<State> states = _context.States.ToList();
            var abc = _context.States.Where(s => s.Country_id == Country_id).ToList();
            foreach (var state in states)
            {
                model.States.Add(new SelectListItem { Value = state.Country_id.ToString(), Text = state.StateName });

            }
            return Json(abc);


        }

        public JsonResult GetCityList(int StateId)
        {
            CascadingModel model = new CascadingModel();

            List<City> cities = _context.Cities.ToList();
            var abcd = _context.Cities.Where(s => s.StateId == StateId).ToList();


            return Json(abcd);


        }



    }
}
