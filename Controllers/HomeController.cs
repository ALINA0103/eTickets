using eTickets.Data;
using eTickets.Models;
using eTickets.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eTickets.Controllers
{
    public class HomeController : Controller
    {

        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }


        //public IActionResult Index()
        // {
        //     List<SelectListItem> country = new()
        //     {
        //      new SelectListItem { Value = "1", Text = "India" },
        //         new SelectListItem { Value = "2", Text = "Australia" },
        //         new SelectListItem { Value = "3", Text = "England" },
        //         new SelectListItem { Value = "4", Text = "Pakistan" },
        //         new SelectListItem { Value = "5", Text = "Nepal" },
        //         new SelectListItem { Value = "6", Text = "bhutan" },

        //     };
        //     ViewBag.country = country;
        //     return View();


        // }
        //public IActionResult Index(Country model)
        //{
        //    if (_context.Countries.Any(x => x.Country_Name == model.Country_Name))
        //    {
        //        Country obj1 = new Country();



        //        List<Country> countryList = _context.Countries.ToList();
        //        ViewBag.Country = new SelectList(countryList, "Country_id", "Country_Name");
        //        obj1.Country_Name = model.Country_Name;
        //        obj1.Country_id = model.Country_id;

        //        _context.Countries.Add(obj1);
        //        _context.SaveChanges();


        //    }
        //    return View();
        //}
        public IActionResult Index()
        { 
            ContriesViewModel model = new ContriesViewModel();
            List<Country> cotries = _context.Countries.ToList();
            
            List<SelectListItem> selectList = new List<SelectListItem>();
            foreach (var country in cotries)
            {
                selectList.Add(new SelectListItem { Value = country.Country_id.ToString(), Text = country.Country_Name });
            }
            //ViewBag.Countries = selectList;
            model.cotries = selectList;
            return View(model);
        }
        public JsonResult getstatebyid(int id)
        {
            List<State> list = new List<State>();
            list = _context.States.Where(x => x.Id == id).ToList();
            list.Insert(0, new State { Id= 0, StateName = "Please Select State" });
            return Json(new SelectList(list, "Id", "Name"));

        }
    }
}
