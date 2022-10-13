using eTickets.Data;
using eTickets.Data.ViewModel;
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
        List<ShoppingCartModel> li = new List<ShoppingCartModel>();

        

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
        public IActionResult AddToCart(int Id, int MinusOrPlus)
        {
            int userId = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            if (_context.Cart.Any(x => x.User_fk == userId && x.Movie_fk == Id))
            {
                if (MinusOrPlus == 0)
                {
                    var abc = _context.Cart.Where(x => x.User_fk == userId && x.Movie_fk == Id).FirstOrDefault();
                    abc.Quantity = abc.Quantity - 1;
                    _context.Cart.Update(abc);
                }

                else
                {
                    var abc = _context.Cart.Where(x => x.User_fk == userId && x.Movie_fk == Id).FirstOrDefault();
                    abc.Quantity = abc.Quantity + 1;
                    _context.Cart.Update(abc);
                }
            }
            else
            {
                Cart cv = new Cart
                {
                    User_fk = userId,
                    Movie_fk = Id,
                    Quantity = 1,
                };
                _context.Cart.Add(cv);


            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult ViewCart()
        {
            ViewCartVC ob = new ViewCartVC();
            var userId = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            var cart = _context.Cart.Where(x => x.User_fk == userId).ToList();
            if(cart.Count() > 0)
            {
                foreach(var item in cart)
                {
                    Movie movie = _context.Movies.Find(item.Movie_fk);
                    Data.ViewModel.Moviesvm moviesvm = new Data.ViewModel.Moviesvm();
                    moviesvm.Id = movie.Id;
                    moviesvm.Name = movie.Name;
                    moviesvm.Description = movie.Description;
                    moviesvm.Price  = (double)(movie.Price);
                    moviesvm.Quantity = item.Quantity;
                    moviesvm.Photo = movie.ImageUrl;
                    moviesvm.TotalPrice = (decimal)(movie.Price * item.Quantity);
                    ob.Movies.Add(moviesvm);

                    ob.Quantity = (int)(ob.Movies?.Sum(x => x.Quantity));
                    


                }

            }
            return View("ViewCart", ob);
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
                        HttpContext.Session.SetString("UserId", model.Id.ToString());
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
        public IActionResult UserSignUp()
        {

            return View();
        }

        [HttpPost]
        public IActionResult UserSignUp(UserLogins model)
        {
            if (ModelState.IsValid)
            {
                UserLogins uss = new UserLogins
                {
                    User_Name = model.User_Name,
                    password = model.password,

                };

                _context.UserLogin.Add(uss);
                _context.SaveChanges();
            }
            return RedirectToAction("UserLogin");
        }

        public ActionResult UserLogin()
        {
            int userId = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            if(userId == 0)
            {
                HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return View();
            }
            return RedirectToAction("index");
        }



        [HttpPost]
        public ActionResult UserLogin(UserLogins model)
        {
            if (ModelState.IsValid)
            {
                var data = _context.UserLogin.Where(x => x.User_Name == model.User_Name && x.password == model.password).FirstOrDefault();
                if (data != null)
                {
                    var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, data.User_Name) },
                     CookieAuthenticationDefaults.AuthenticationScheme);
                    var Principal = new ClaimsPrincipal(identity);
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, Principal);
                    HttpContext.Session.SetString("UserName", data.User_Name);

                    HttpContext.Session.SetString("UserId", data.UserId.ToString());


                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorPassword"] = "Invalid Username or Password";
                    return View(model);
                }
            }

            else
            {
                return View(model);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var storedCookies = Request.Cookies.Keys;
            foreach (var cookies in storedCookies)
            {
                Response.Cookies.Delete(cookies);
            }
            return RedirectToAction("UserLogin", "Movies");
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
