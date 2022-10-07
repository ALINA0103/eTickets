using eTickets.Data;
using eTickets.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace eTickets.Controllers
{
    public class MoviesController : Controller

    {
        
        private readonly AppDbContext _context;

        

        public MoviesController(AppDbContext context)
        {

            _context = context;
        }

        [HttpGet]
       
        public async Task<IActionResult> Index(string SerachString)
        {

            if (SerachString != null)
            {
                var allmovies = await _context.Movies.Where(x => x.Name.ToLower().Contains(SerachString.ToLower())).ToListAsync();
                return View(allmovies);
            }

            else
            {
                var allmovies = await _context.Movies.Include(n => n.Cinema).OrderBy(n => n.Name).ToListAsync();
                return View(allmovies);
            }
        }


        public IActionResult SignUp()
        {

            return View();
        }

        [HttpPost]
        public IActionResult SignUp(AdminLogin model)
        {
            if (ModelState.IsValid)
            {
                AdminLogin us = new AdminLogin
                {
                    UserName = model.UserName,
                    Password = model.Password,

                };

                _context.AdminLogins.Add(us);
                _context.SaveChanges();
            }
            return RedirectToAction("Login");
        }

        public ActionResult Login()
        {
            return View();
        }



        [HttpPost]


        public ActionResult Login(AdminLogin model)
        {
            if (ModelState.IsValid)
            {

                var data = _context.AdminLogins.Any(x => x.UserName == model.UserName && x.Password == model.Password);
                if (data)
                {
                    bool isValid = data;
                    if (isValid)
                    {
                        var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, model.UserName) },
                         CookieAuthenticationDefaults.AuthenticationScheme);
                        var Principal = new ClaimsPrincipal(identity);
                        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, Principal);
                        HttpContext.Session.SetString("UserName", model.UserName);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["errorPassword"] = "Invalid Password";
                        return View(model);
                    }
                }
                else
                {
                    TempData["errorMessage"] = "UserName is not found";
                    return View(model);
                }
            }

            else
            {
                return View(model);
            }
        }

        public async Task<IActionResult> Details(int id)
        {

            var data = _context.Movies.Find(id);
            return View(data);



        }
        public async Task<IActionResult> Filter(string searchString)
        {
            var allMovies = await _context.Movies.ToListAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = allMovies.Where(n => n.Name.ToLower().Contains(searchString.ToLower()) || n.Description.ToLower().Contains(searchString.ToLower())).ToList();

                var filteredResultNew = allMovies.Where(n => string.Equals(n.Name, searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.Description, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();

                return View("Index", filteredResultNew);
            }

            return View("Index", allMovies);
        }

    }
}
